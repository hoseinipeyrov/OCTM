using OCTM.Application.Interfaces;
using OCTM.Application.Services;
using OCTM.Domain.CommandHandlers;
using OCTM.Domain.Commands;
using OCTM.Domain.Core.Bus;
using OCTM.Domain.Core.Events;
using OCTM.Domain.Core.Notifications;
using OCTM.Domain.EventHandlers;
using OCTM.Domain.Events;
using OCTM.Domain.Interfaces;
using OCTM.Infra.CrossCutting.Bus;
using OCTM.Infra.CrossCutting.Identity.Authorization;
using OCTM.Infra.CrossCutting.Identity.Models;
using OCTM.Infra.CrossCutting.Identity.Services;
using OCTM.Infra.Data.Context;
using OCTM.Infra.Data.EventSourcing;
using OCTM.Infra.Data.Repository;
using OCTM.Infra.Data.Repository.EventSourcing;
using OCTM.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace OCTM.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IContainerShipAppService, ContainerShipAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<ContainerShipRegisteredEvent>, ContainerShipEventHandler>();
            services.AddScoped<INotificationHandler<ContainerShipUpdatedEvent>, ContainerShipEventHandler>();
            services.AddScoped<INotificationHandler<ContainerShipRemovedEvent>, ContainerShipEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<CreateNewContainerShipCommand, bool>, ContainerShipCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateContainerShipCommand, bool>, ContainerShipCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveContainerShipCommand, bool>, ContainerShipCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContainerShipRepository, ContainerShipRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<OCTMContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddDbContext<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}