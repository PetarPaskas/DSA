



//piles - list of bananas in ith pile
//piles[i](pile) is number of bananas in the ith pile
//h - hours you are given to eat all bananas

//decide minimum bananas/h eating speed (k) and return it

//koko can eat at most an entire pile in an hour
// h >= piles.Length

//minimum eating speed koji je potreban kako bi koko pojela sve banane
//imamo piles [3, 6, 7, 11] i 8h da pojedemo
//koji je minimum eating speed; k?


/*
 Znaci ne maksimum banana/h
    Ako kazemo da jedemo 11 banana/h onda cemo sve banane pojesti za 4h
    Ako kazemo da jedemo 1 banana/h onda cemo sve banane pojesti za *preko 8h* tj docemo do 3. pile i ponestace vremena

Kako je cilj da vidimo koliko MINIMALNO sati je potrebno da se pojedu sve banane, to znaci da rezultat mora biti <= h
Brute force resenje bi znacilo da krenemo od npr 1 i onda povecavamo za 1 i gledamo da li cemo stici pojesti sve banane.

npr za pile 0 => piles[0]/bananapohr(1) => 3/1 => 3h
Ukoliko dodjemo do poslednjeg i imamo jos raspolozivih sati onda je to minimalni
U ovom slucaju cemo doci do piles[2] i currentSpentHours + piles[2]/bananapohr :7 ce biti Vece od dozvoljenih sati. 
 */

int[] piles = [3, 6, 7, 11];
piles = [25, 10, 23, 4];
int h = 8;
h = 4;

int minHours = BruteForceMinEatingSpeed(piles, h);

Console.WriteLine(minHours);

int BruteForceMinEatingSpeed(int[] piles, int h)
{

    int k = 1;

    while (true)
    {
        long currentSpentHours = 0;
        foreach (var pile in piles)
        {
            currentSpentHours += (int)Math.Ceiling((double)pile / k);
        }


        if (currentSpentHours <= h)
            return k;

        k++;
    }

}