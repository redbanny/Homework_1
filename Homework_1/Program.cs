using System.Text;

MainWork();


static void MainWork()
{
    int lineSize = 0; 
    int width = 0;
    string inputText = string.Empty;

    while (true)
    {
        while (true)
        {
            Console.WriteLine("Введите размерность таблицы:");
            try
            { lineSize = int.Parse(Console.ReadLine()); }
            catch
            {
                Console.WriteLine("Вы ввели некорректный размер.");
                continue;
            }
            if (lineSize < 1 || lineSize > 6)
            {
                Console.WriteLine("Размерность должна находиться в предела от 1 до 6");
                continue;
            }
            break;
        }
        while (true)
        {
            Console.WriteLine("введите произвольный текст:");
            inputText = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputText))
            {
                Console.WriteLine("Текст пустой");
                continue;
            }
            break;
        }
        width = lineSize * 2 + inputText.Length;
        if(width > 40)
        {
            Console.WriteLine("Ширина > 40");
            continue;
        }
        break;
    }
    var sb = BuildHorizontLine(width);
    Console.WriteLine(sb);
    for (int i = 1; i <= 3; i++)
    {                
        DrawTable(i, (lineSize * 2) + 1, inputText);
        Console.WriteLine(sb);
    }
    Console.Read();
}

static void DrawTable(int tableRow, int size, string text)
{
    switch (tableRow)
    {
        case 1:
            DrawFirstRow(size, text);
            break;
        case 2:
            DrawSecondRow(size, (size - 1 + text.Length));
            break;
        case 3:
            DrawThirdRows(size, (size - 1 + text.Length));
            break;
        default:
            break;
    }
}

static void DrawFirstRow(int size, string text)
{
    Console.WriteLine(BiuldStringFirstLine(text, size));            
}

static StringBuilder BuildHorizontLine(int size)
{            
    var sb = new StringBuilder("+");
    for(int i = 1; i < size; i++)
        sb.Append("+");
    return sb;
}

static StringBuilder BiuldStringFirstLine(string text, int size)
{
    var sb = new StringBuilder();
    for (int h = 1; h <= size; h++)
    { 
        for (int i = 1; i <= size + text.Length - 1; i++)
        {
            if (i == 1 || i == (size + text.Length - 1))
            {
                if (i == (size + text.Length - 1) && h!= size)
                    sb.Append("+\n");
                else if(i == (size + text.Length - 1) && h == size)
                    sb.Append("+");
                else
                    sb.Append("+");
            }
            else if (i == ((size - 1) / 2) + 1 && h == ((size - 1) / 2) + 1)
            {
                sb.Append(text);
                i += (text.Length - 1);
            }
            else
                sb.Append(" ");
        }
    }
    return sb;
}

static void DrawSecondRow(int w, int h)
{
    Console.WriteLine(BiuldStringSecondLine(w,h));
}

static StringBuilder BiuldStringSecondLine(int size, int height)
{
    StringBuilder sb = new StringBuilder();
    for (int h = 1; h <= size; h++)
    {
        sb.Append("+");
        for (int w = 1; w <= height -1; w++)
        {
            if (h % 2 == 0)
            {
                if(w%2 == 0 && w != height - 1)
                    sb.Append("+");
                else if(w % 2 != 0 && w != height - 1)
                    sb.Append(" ");
            }
            else
            {
                if (w % 2 == 0 && w != height - 1)
                    sb.Append(" ");
                else if (w % 2 != 0 && w != height - 1)
                    sb.Append("+");
            }
        }
        if(h == size)
            sb.Append("+");
        else
            sb.Append("+\n");
    }
    return sb;
}

static void DrawThirdRows(int w, int h)
{
    Console.WriteLine(BuildStringThirdLine(w, h));
}

static StringBuilder BuildStringThirdLine(int size, int height)
{
    StringBuilder sb = new();
    for(int h = 1; h <= height - 2; h++) 
    {
        sb.Append("+");
        for(int w = 1; w <= height - 2; w++)
        {
            if(w == h || w == height - 1 - h)
                sb.Append("+");
            else
                sb.Append(' ');
        }
        if (h == height - 2)
            sb.Append("+");
        else
            sb.Append("+\n");
    }
    return sb;
}