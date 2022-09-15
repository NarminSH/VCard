using System;


public class CardService
{
    async public Task<string> CreateAsync(Card entity)
    {
        using (VCardDbContext dbContext = new VCardDbContext())
        {
            await dbContext.Set<Card>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            Console.WriteLine($"BEGIN:VCARD\nFN:{entity.First} {entity.Last}\nN:{entity.Last};{entity.First}\nEND:VCARD");
            return "added";
        }
    }
}


