public class HeightCat{
     public string CatHt(double num){
        if (num < 150){
            return "Dwarf";
        }
        else if(num < 165){
            return "Average";
        }
        else if(num <= 190){
            return "Tall";
        }
        else{
            return "Abnormal";
        }
    }
}