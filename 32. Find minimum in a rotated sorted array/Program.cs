
//Console.WriteLine(BinarySearch([1, 2, 3], 3));




//Da array bude rotiran, to bi znacilo da je  
//poslednji item arraya pomeren na vrh arraya.

//Znaci ukoliko mi imamo array sa [1,2,3] onda kada ga jednom rotiramo to je [3, 2, 1]
//Zadatak nam garantuje da je izvorni array sortiran. Ono sto treba da uradimo jeste da pronadjemo tu tacku
//u kojoj je "stvaran pocetak sortiranog niza" i tako cemo doci do najmanjeg elementa. 

int[] items = [4, 5, 6, 7, 0, 1, 2];

Console.WriteLine(FindMinimum(items));
int FindMinimum(int[] items){

    if (items[0] < items[items.Length - 1])
        return items[0];

    int left = 0;
    int right = items.Length - 1;
    int min = items[left];

    while (left <= right) //3. priblizavamo sve dok se ne izjednace ili ne ukrste
    {
        if (items[left] < min) //4. a radimo proveru ukoliko je left pointer takodje manji od min
            min = items[left];

        int middle = (left + right) / 2;

        if (items[middle] < min)
            min = items[middle];

        if (items[middle] >= items[left])
            left = middle + 1;  //1. left pointer pomeramo u desno skoro stalno
        else
            right = middle - 1; //2. kada left pointer ne mozemo vise da pomeramo u desno, onda desni priblizavamo levom
    }

    return min; //6. trazimo najmanji item!!!

}


