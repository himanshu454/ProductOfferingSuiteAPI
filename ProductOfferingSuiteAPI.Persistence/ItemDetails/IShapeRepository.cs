using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface IShapeRepository
    {
        Task<List<ShapeModel>> GetShape();
    }
}