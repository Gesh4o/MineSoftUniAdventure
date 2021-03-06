﻿using System;

class BitsExchange
{
    static void Main()
    {
        // Tова не е авторско решение и е с приложени коментари на това как аз си обяснявам задачата.
        // Целта е поне, ако проверяващия също като мен много не ги чатка, да види едно "сдъвкано" от мен решение (peace bro!).
        // Следвам примера с 5351.

        Console.Write("Please insert an integer: ");
        uint n = uint.Parse(Console.ReadLine());

        //Премествам битовете на въведеното число с 3 позиции надясно и прилагам 'И' с битовете на числото 7,които излгеждат така - ...00111
        //Като резултат получавам тези три бита, които са на 3-та,4-та и 5-та позиция
        uint firstBits = (n >> 3);
        firstBits = firstBits & 7;

        //Подобно става и тук (Т.е представям си, че вече битовете са отделени тук, което е така...) -...000000 - резултат
        uint secondBits = (n >> 24) & 7;

        // В сега ще създам "маските",нужни за разместването на битовете
        //Местя битовите позиции на числото 7 с 3 наляво 
        //Като резултат получвам: ...00111000.
        uint mask0 = 7 << 3;
        
        uint mask1 = 7 << 24;
        //Тук резултата също е подобен: ...00111000000000000000000000000

        n = n & mask0;
        n |= (secondBits << 3);
        //Ползвам логическо 'И' с противоположното на маската и заедно с битовете на числото от условието
        //00000000 00000000 00010100 11100111 -n - битовете на въведеното число
        //11111111 11111111 11111111 11000111 -~mask0 - "преобърнатата" маска
        //00000000 00000000 00010100 11000111 -резултат от операцията и него събираме с 'ИЛИ' с вторите битове преместени на началните позиции
        //00000000 00000000 00000000 00000000 - -seconBits
        //00000000 00000000 00010100 11000111 - така в конкретния случай изглежда операнда n= n|(secondBits << 3)- n
        n = n & ~mask1;
        n |= (firstBits << 24);
        //Стойността на "n" е вече променена и с нея ще направим следващите операции, аналогични на предишните -
        //Първите битове отиват на местото на вторите в този случай
        //00000000 00000000 00010100 11000111 -n
        //11111011 11111111 11111111 11111111 -~mask1
        //00000000 00000000 00010100 11000111 -резултата от n & ~mask1
        //00000100 00000000 00000000 00000000 -firstbits<<24
        //00000100 00000000 00010100 11000111 - резултата от операцията n |= firstbits<<24

        Console.WriteLine(n);
        //Ако не си разбираш задачата, се надявам да е по-малко ясно сега, поне самото решение на тази конкретна.
        //Ако пък си супер пич и си ги разбираш не гледай какви съм ги писал и не ме хейтвай - опитвам се да помогна!
    }
}