using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            this._repository = studentRepository;
            this._emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validate
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar seu cadastro.");
            }
            // Verificar se documento já está cadastrado
            if (this._repository.DocumentExists(command.Document))
            {
                AddNotifications(command);
                return new CommandResult(false, "Este CPF já está em uso.");
            }   
            // Verificar se e-mail já está cadastrado
            if(this._repository.EmailExists(command.Email))
            {
                AddNotifications(command);
                return new CommandResult(false, "Esse e-mail já está em uso.");
            }
            // Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(
                command.PayerStreet, 
                command.PayerNumber, 
                command.PayerNeighborhood, 
                command.PayerCity, 
                command.PayerState, 
                command.PayerCountry, 
                command.PayerZipCode
            );
            // Gerar Entidades
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, 
                command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, student);
            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Chegar notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as informações
            this._repository.CreateSubscription(student);

            // Enviar e-mail de boas vindas
            this._emailService.Send(
                student.Name.ToString(), 
                student.Email.Address, 
                "Bem-vindo", 
                "Sua assinatura foi criada com sucesso!"
            );

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }        
        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}