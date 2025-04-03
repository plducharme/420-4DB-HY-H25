var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
  
    serviceBuilder.AddService<ContactService>();
    serviceBuilder.AddServiceEndpoint<ContactService, IContactService>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Contact.svc");


    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;


});

app.Run();