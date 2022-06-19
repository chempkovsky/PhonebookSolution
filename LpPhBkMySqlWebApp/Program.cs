using LpPhBkContext.PhBk;
using LpPhBkControllers.Consumers;
using LpPhBkViews.PhBk;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<LpPhbkDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("LpPhBkConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LpPhBkConnection"))));
builder.Services.AddDbContext<LpEmpPhBkContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("LpEmpPhBkConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LpEmpPhBkConnection"))));
builder.Services.AddDbContext<LpPhnPhBkContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("LpPhnPhBkConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LpPhnPhBkConnection"))));


#region MassTransit config

var phbkDivisionViewExtForLkUpConf = new PhbkDivisionViewExtForLkUpConf();
configuration.GetSection(PhbkDivisionViewExtForLkUpConf.ConfName).Bind(phbkDivisionViewExtForLkUpConf);
builder.Services.AddMassTransit(x => {
    x.AddConsumer<PhbkDivisionViewExtForLkUpMsgConsumer>(typeof(PhbkDivisionViewExtForLkUpMsgConsumerDefinition));
    //.Endpoint(e => { 
    //    e.Name = "phbk-division-view"; 
    //});

    x.UsingRabbitMq((context, configurator) => {
        configurator.Host(phbkDivisionViewExtForLkUpConf.HostName, phbkDivisionViewExtForLkUpConf.VirtualHostName, h => {
            h.Username(phbkDivisionViewExtForLkUpConf.Username);
            h.Password(phbkDivisionViewExtForLkUpConf.Password);
            if (phbkDivisionViewExtForLkUpConf.ClusterIpAddresses != null)
            {
                if (phbkDivisionViewExtForLkUpConf.ClusterIpAddresses.Length > 0)
                {

                    h.UseCluster((configureCluster) => {
                        for (int i = 0; i < phbkDivisionViewExtForLkUpConf.ClusterIpAddresses.Length; i++)
                        {
                            configureCluster.Node(phbkDivisionViewExtForLkUpConf.ClusterIpAddresses[i]);
                        }
                    });
                }
            }
            // h.PublisherConfirmation = true;
            // h.ConfigureBatchPublish(configure => { });
        });
        configurator.ConfigureEndpoints(context);
        // 
        // Quorum Queue settings
        //
        // configurator.SetQuorumQueue(3);
        //
    });
});

var phbkEmployeeViewExtForLkUpConf = new PhbkEmployeeViewExtForLkUpConf();
configuration.GetSection(PhbkEmployeeViewExtForLkUpConf.ConfName).Bind(phbkEmployeeViewExtForLkUpConf);
builder.Services.AddMassTransit<IBusLpPhbkEmployee>(x => {
    x.AddConsumer<PhbkEmployeeViewExtForLkUpMsgConsumer>(typeof(PhbkEmployeeViewExtForLkUpMsgConsumerDefinition));
    //.Endpoint(e => { 
    //    e.Name = "phbk-division-view"; 
    //});

    x.UsingRabbitMq((context, configurator) => {
        configurator.Host(phbkEmployeeViewExtForLkUpConf.HostName, phbkEmployeeViewExtForLkUpConf.VirtualHostName, h => {
            h.Username(phbkEmployeeViewExtForLkUpConf.Username);
            h.Password(phbkEmployeeViewExtForLkUpConf.Password);
            if (phbkEmployeeViewExtForLkUpConf.ClusterIpAddresses != null)
            {
                if (phbkEmployeeViewExtForLkUpConf.ClusterIpAddresses.Length > 0)
                {

                    h.UseCluster((configureCluster) => {
                        for (int i = 0; i < phbkEmployeeViewExtForLkUpConf.ClusterIpAddresses.Length; i++)
                        {
                            configureCluster.Node(phbkEmployeeViewExtForLkUpConf.ClusterIpAddresses[i]);
                        }
                    });
                }
            }
            // h.PublisherConfirmation = true;
            // h.ConfigureBatchPublish(configure => { });
        });
        configurator.ConfigureEndpoints(context);
        // 
        // Quorum Queue settings
        //
        // configurator.SetQuorumQueue(3);
        //
    });
});


var phbkPhoneViewExtForLkUpConf = new PhbkPhoneViewExtForLkUpConf();
configuration.GetSection(PhbkPhoneViewExtForLkUpConf.ConfName).Bind(phbkPhoneViewExtForLkUpConf);
builder.Services.AddMassTransit<IBusLpPhbkPhone>(x => {
    x.AddConsumer<PhbkPhoneViewExtForLkUpMsgConsumer>(typeof(PhbkPhoneViewExtForLkUpMsgConsumerDefinition));
    //.Endpoint(e => { 
    //    e.Name = "phbk-division-view"; 
    //});

    x.UsingRabbitMq((context, configurator) => {
        configurator.Host(phbkPhoneViewExtForLkUpConf.HostName, phbkPhoneViewExtForLkUpConf.VirtualHostName, h => {
            h.Username(phbkPhoneViewExtForLkUpConf.Username);
            h.Password(phbkPhoneViewExtForLkUpConf.Password);
            if (phbkPhoneViewExtForLkUpConf.ClusterIpAddresses != null)
            {
                if (phbkPhoneViewExtForLkUpConf.ClusterIpAddresses.Length > 0)
                {

                    h.UseCluster((configureCluster) => {
                        for (int i = 0; i < phbkPhoneViewExtForLkUpConf.ClusterIpAddresses.Length; i++)
                        {
                            configureCluster.Node(phbkPhoneViewExtForLkUpConf.ClusterIpAddresses[i]);
                        }
                    });
                }
            }
            // h.PublisherConfirmation = true;
            // h.ConfigureBatchPublish(configure => { });
        });
        configurator.ConfigureEndpoints(context);
        // 
        // Quorum Queue settings
        //
        // configurator.SetQuorumQueue(3);
        //
    });
});


#endregion


#region authentification
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
builder.Services.AddHttpContextAccessor();
#endregion


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        builder => {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
