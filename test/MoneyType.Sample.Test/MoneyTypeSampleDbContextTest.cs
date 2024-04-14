using Microsoft.EntityFrameworkCore;

namespace MoneyType.Sample.Test;

[TestClass]
public sealed class MoneyTypeSampleDbContextTest
{
#pragma warning disable CS8618
  private MoneyTypeSampleDbContext _dbContext;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _dbContext = new MoneyTypeSampleDbContext();
    _dbContext.Database.EnsureCreated();
  }

  [TestCleanup]
  public void Cleanup()
  {
    _dbContext?.Database.EnsureDeleted();
    _dbContext?.Dispose();
  }

  [TestMethod]
  public async Task SaveChangesAsync_Product_ProductSaved()
  {
    // Arrange
    Guid productId = Guid.NewGuid();
    ProductEntity productToSave = new()
    {
      ProductId = productId,
      Name      = "Test product",
      Price     = Money.USD(1500UL),
    };
    _dbContext.Add(productToSave);

    // Act
    await _dbContext.SaveChangesAsync();

    // Assert
    ProductEntity? savedProduct = await _dbContext.Set<ProductEntity>()
                                                  .AsNoTracking()
                                                  .Where(entity => entity.ProductId == productId)
                                                  .SingleOrDefaultAsync();

    Assert.IsNotNull(savedProduct);
    Assert.AreEqual(productToSave.Name , savedProduct.Name );
    Assert.AreEqual(productToSave.Price, savedProduct.Price);
  }
}
