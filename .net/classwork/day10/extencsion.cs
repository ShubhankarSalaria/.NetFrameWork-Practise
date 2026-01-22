public static class StringExtension
{
    public static bool Palindrome(this string str)
    {
        int len = str.Length;
        bool flag=true;
        for(int i =0 ; i< len ; i++)
        {
            if (str[i] != str[len - i-1])
            {
                flag=false;
            }
        }
        return flag;
    }
}