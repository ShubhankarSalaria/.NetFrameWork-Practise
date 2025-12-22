public class LargestOfThree{
     public int MaxThree(int a ,  int b , int c ){
        if(a>b){
            if(a>c){
                return a; 
            }
            else{
                return c; 
            }
        }
        else if(b>c){
            return b;
        }
        else{
            return c ;
        }
    }
}