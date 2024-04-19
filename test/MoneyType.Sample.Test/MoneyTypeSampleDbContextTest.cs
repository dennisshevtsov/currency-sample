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
      Price     = Money.USD(cents: 1500UL),
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

  [TestMethod]
  public async Task ToListAsync_EqualToUSD100_ProductByUSD100Returned()
  {
    // Arrange
    ProductEntity productByUSD100 = new()
    {
      ProductId = Guid.NewGuid(),
      Name      = "Product by USD100",
      Price     = Money.USD(cents: 10000UL),
    };
    _dbContext.Add(productByUSD100);

    ProductEntity productByUSD200 = new()
    {
      ProductId = Guid.NewGuid(),
      Name      = "Product by USD200",
      Price     = Money.USD(cents: 20000UL),
    };
    _dbContext.Add(productByUSD200);

    ProductEntity productByEUR100 = new()
    {
      ProductId = Guid.NewGuid(),
      Name      = "Product by EUR100",
      Price     = Money.EUR(cents: 10000UL),
    };
    _dbContext.Add(productByEUR100);

    ProductEntity productByEUR200 = new()
    {
      ProductId = Guid.NewGuid(),
      Name      = "Product by EUR200",
      Price     = Money.EUR(cents: 20000UL),
    };
    _dbContext.Add(productByEUR200);

    await _dbContext.SaveChangesAsync();

    // Act
    Money usd100 = Money.USD(cents: 10000UL);
    List<ProductEntity> products = await _dbContext.Set<ProductEntity>()
                                                   .AsNoTracking()
                                                   .Where(entity => entity.Price == usd100)
                                                   .ToListAsync();

    // Assert
    Assert.AreEqual(1, products.Count);
    Assert.AreEqual(productByUSD100.ProductId, products[0].ProductId);
    Assert.AreEqual(productByUSD100.Name     , products[0].Name);
    Assert.AreEqual(productByUSD100.Price    , products[0].Price);
  }
}
