using LpPhBkViews.PhBk;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhBkContext.AspNetReg;
using PhBkContext.Auth;
using PhBkContext.PhBk;
using PhBkControllers.MassTansitBuses;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<PhbkDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("PhBkConnection")));


builder.Services.AddDbContext<aspnetchckdbcontext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("AuthConnection")));

#region authentification
builder.Services.AddDbContext<AspNetRegistrationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("AspNetRegConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetRegistrationDbContext>().AddDefaultTokenProviders();
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


#region MassTransit config
var phbkDivisionViewExtForLkUpConf = new PhbkDivisionViewExtForLkUpConf();
configuration.GetSection(PhbkDivisionViewExtForLkUpConf.ConfName).Bind(phbkDivisionViewExtForLkUpConf);
builder.Services.AddMassTransit(x => {

    x.AddRequestClient<IPhbkDivisionViewExtForLkUpMsg>();

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

    x.AddRequestClient<IPhbkEmployeeViewExtForLkUpMsg>();

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
    x.AddRequestClient<IPhbkPhoneViewExtForLkUpMsg>();

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
