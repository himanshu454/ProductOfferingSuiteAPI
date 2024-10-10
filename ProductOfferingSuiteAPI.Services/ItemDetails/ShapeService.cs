using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.ItemDetails;

namespace DesignComplexityAPI.Services.ItemDetails
{
    public class ShapeService : IShapeService
    {
        private readonly IShapeRepository _shapeRepository;

        public ShapeService(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public async Task<TransactionDataModel<List<ShapeModel>>> GetShape()
        {
            TransactionDataModel<List<ShapeModel>> Shape = new TransactionDataModel<List<ShapeModel>>();
            Shape.Data = await _shapeRepository.GetShape();
            Shape.ReturnCode = 0;
            Shape.Message = "Data Shown Properly";
            return Shape;
        }
    }
}
