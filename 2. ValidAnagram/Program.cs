
//Didn't understand the assignment.
//Thought anagram is a string which is read the same from the beginning and the ending. 
//anagram is a word which just contains same characters. 


var isAnagram = IsAnagram("racecar","carrace");
Console.WriteLine(isAnagram);

//Console.WriteLine(5 % 2);

bool IsAnagramTheMistakenOne(string firstWord, string secondWord) {

    if(firstWord.Length != secondWord.Length)
        return false;

    var counter = firstWord.Length;
    //Console.WriteLine(counter);

    int half = counter / 2;
    int startCount = (counter % 2) == 0 ? half : half+1;

    for(int i = startCount; i<counter;i++){
        var otherSide = (counter) % (i+1);
        //Console.WriteLine("i: " + i + " - " + "modulus: " + modulus);
        if(firstWord[i] != secondWord[otherSide])
        return false;
    }
    return true;
}



bool IsAnagram(string firstWord, string secondWord) {

    var firstOrdered = firstWord.OrderBy(x=>x).ToArray();
    var secondOrdered = secondWord.OrderBy(x=>x).ToArray();

    for(int i = 0;i<firstOrdered.Length;i++){
        if(firstOrdered[i] != secondOrdered[i])
        return false;
    }
    return true;

}





