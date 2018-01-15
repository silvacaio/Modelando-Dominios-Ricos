using System;
using Flunt.Notifications;
using Flunt.Validations;
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
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fast fail validade
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "não foi possivel realizar a assinatura.");
            }

            //verificar se documento ja esta cadastrado
            //verificar se e-mail ja esta cadastrados
            // if(_repository.DocumentExist(command.Document))

            AddNotifications(new Contract()
                         .Requires()
                         .IsFalse(_repository.DocumentExist(command.Document), "Document", "Este documento já está cadastrado")
                         .IsFalse(_repository.EmailExist(command.Email), "Email", "Este Email já está cadastrado"));

            //if(Invalid)
            //return new CommandResult(false, Notifications.)


            //Gerar VOS
            var name = new Name(command.FirtsName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);

            //Gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
           // var address = new Address("Borges de Medeiros", "1234", "Centro", "Flores da Cunha", "RS", "Brasil", "65325123");
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid,
            new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, new Email(command.PayerEmail));

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar validacoes
            AddNotifications(name, document, email, student, subscription, payment);


            if (Invalid)
                return new CommandResult(false, "Não foi possivel realizar a assinatura.");

            //Salvar informações
            _repository.CreateSubscription(student);
            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao site", "Seja bem vindo");

            //retornar informações          

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}