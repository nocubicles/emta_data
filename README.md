This project takes data from https://www.emta.ee/et/kontaktid-ja-ametist/avaandmed-maksulaekumine-statistika/tasutud-maksud-kaive-ja-tootajate-arv and formats them and saves to a database.

Data can be found from data.csv file.

To get this project to work:

1. Create a file "emta_data.db" to this location C:\Users\<YourUser>\Documents\Data
2. Run `dotnet ef migrations add initial`
3. Run `dotnet ef database update`
4. Run `dotnet run https://ncfailid.emta.ee/s/a5EwcgYQDib3yoR/download/tasutud_maksud_2023_i_kvartal.xlsx 2023 1`

All the excel files can be found from here: https://www.emta.ee/eraklient/amet-uudised-ja-kontakt/uudised-pressiinfo-statistika/statistika-ja-avaandmed