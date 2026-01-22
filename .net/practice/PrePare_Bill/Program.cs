using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public enum CommodityCategory 
{
    Furniture,
    Grocery,
    Service
}

class Commodity
{
    public CommodityCategory Category{get; set;}
    public string CommodityName{get; set;}
    public int CommodityQuantity{get; set;}
    public double CommodityPrice{get; set;}

    public Commodity(CommodityCategory category , string commodityName , int commodityQuantity , double commodityPrice )
    {
        this.Category=category;
        this.CommodityName=commodityName;
        this.CommodityQuantity=commodityQuantity;
        this.CommodityPrice=commodityPrice;
    }
}

class PrepareBill
{
    private readonly IDictionary<CommodityCategory,double>_taxRates;
    public PrepareBill()
    {
        _taxRates=new IDictionary<CommodityCategory,double>();
    }
}