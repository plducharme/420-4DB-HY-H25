# Générer une BD sqlite en code first
    - Créer une base de données sqlite avec le nom "mobile.db"
    - Créer un projet console utilisant EF Core et SQLite
    - Installer les packages NuGet suivants:
        - Microsoft.EntityFrameworkCore
        - Microsoft.EntityFrameworkCore.Sqlite
        - Microsoft.EntityFrameworkCore.Tools

    - Créer un modèle de données (par convention) pour représenter les téléphones mobiles
        - Créer une classe "Marque" avec les propriétés suivantes:
            - Id (int, clé primaire)
            - Nom (string)
            - Pays d'origine (string)
        - Créer une classe "Telephone" avec les propriétés suivantes:
            - Id (int, clé primaire)
            - Marque (Marque)
            - Modèle (string)
            - Prix (decimal)
            - Date de sortie (DateTime)
        - Créer une classe "Client" avec les propriétés suivantes:
            - Id (int, clé primaire)
            - Nom (string)
            - Prénom (string)
            - Email (string)
            - Telephones (List<Telephone>)

# Remodéliser la même BD en utilisant les annotations 



    

