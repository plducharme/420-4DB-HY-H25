using EFCoreUnitTests.Model;

namespace JeuxOlympiquesService;


//Note: Pour fin d'exemple, les services seront dans un seul fichier. Tout dépendant de la grosseur de votre application, il faudrait p-e les découper en un fichier par service

public class JeuxOlympiquesService
{
    private static _4dbJeuxOlympiqueContext? _context;
    private static JeuxOlympiquesService? _service;

    private JeuxOlympiquesService(_4dbJeuxOlympiqueContext context) {
        _context = context;
    }


    public void AddEntraineur(Entraineur entraineur) {
        _context.Entraineurs.Add(entraineur);
        _context.SaveChanges();
    }

    public Entraineur GetEntraineurByNomComplet(String prenom, String nom) { 
        Entraineur entraineur = _context.Entraineurs.Where(e => e.Prenom == prenom && e.Nom == nom).FirstOrDefault();
        return entraineur;

    }

    public int ModifyEntraineur(Entraineur entraineur) { 
        _context.Entraineurs.Update(entraineur);
        return _context.SaveChanges();
    }

    public int RemoveEntraineur(Entraineur entraineur) { 
        _context.Entraineurs.Remove(entraineur);
        return _context.SaveChanges();
    }

    public static JeuxOlympiquesService GetService(_4dbJeuxOlympiqueContext context)
    {
        if (_service == null) {
            _service = new JeuxOlympiquesService(context);
            return _service;
        }
        return _service;
    }

}
