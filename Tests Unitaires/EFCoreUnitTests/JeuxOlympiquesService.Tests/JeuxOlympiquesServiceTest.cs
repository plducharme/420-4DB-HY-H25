using EFCoreUnitTests.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace JeuxOlympiquesService.Tests;

public class JeuxOlympiquesServiceTest : IClassFixture<TestDatabaseFixture>
{
    

    public TestDatabaseFixture Fixture { get; }

    public JeuxOlympiquesServiceTest(TestDatabaseFixture fixture) => Fixture = fixture;  
    
    
    [Fact]
    public void AddEntraineur()
    {
        JeuxOlympiquesService service = JeuxOlympiquesService.GetService(Fixture.CreateContext());
        Entraineur entraineur = new Entraineur
        {
            Prenom = "Gracien",
            Nom = "Laplante"
            
        };
        service.AddEntraineur(entraineur);
        
        
    }

    [Fact]
    public void GetEntraineurByNomComplet()
    {
        JeuxOlympiquesService service = JeuxOlympiquesService.GetService(Fixture.CreateContext());
        Entraineur entraineur = service.GetEntraineurByNomComplet("Lucie", "Langevin");
        Assert.NotNull(entraineur);
        Assert.Equal("Lucie", entraineur.Prenom);
        Assert.Equal("Langevin", entraineur.Nom);


    }



}
