namespace NerdShop.WebApp.Services.Promotions
{
    public interface IPromotion
    {
        decimal TakeTwoPayOne(bool favorite);

        decimal PayThreeForTen(bool favorite, int quantity);
    }
}
