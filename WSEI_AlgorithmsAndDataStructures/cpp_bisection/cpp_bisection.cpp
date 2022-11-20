// Pierwiastek funkcji - metoda bisekcji
// (C)2019 mgr Jerzy Wałaszek
// Metody numeryczne
//--------------------------------------

#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

// Tutaj definiujemy funkcję, której pierwiastek jest wyliczany
//-------------------------------------------------------------

double f(double x)
{
    //return sin(x * x - x + 1 / 3.0) + 0.5 * x; 
    //return (x * x * x * x) - 2 * (x * x) + 0.5;
    /*x = 1;
    cout << x << "X";*/
    //cout << (pow(x, 5) + pow(x, 4) + pow(x, 3) + 3 * pow(x, 2) + pow(x, 1) - 0.5) <<endl;
    return( pow(x, 5) + pow(x, 4) + pow(x, 3) + 3 * pow(x, 2) + pow(x, 1) - 0.5);
}

// Tutaj definiujemy parametry początkowe

double epsx = 1e-14; // Dokładność x
double epsy = 1e-14; // Dokładność y
double a = -0.8;     // Początek przedziału poszukiwań pierwiastka
double b = -0.6;     // Koniec przedziału poszukiwań pierwiastka

// Program główny
//---------------

int main()
{
    // Zmienne

    double fa, fb, fx, x0;

    // Licznik obiegów pętli

    int i = 0;

    // Zmienna informująca o znalezieniu wyniku

    bool result = false;

    setlocale(LC_ALL, "");

    cout << setprecision(15) << fixed;
    cout << "Obliczanie przybliżonego pierwiastka funkcji metodą bisekcji" << endl
        << "------------------------------------------------------------" << endl << endl;

    // Obliczamy i zapamiętujemy wartości funkcji na krańcach przedziału [a,b]

    fa = f(a);
    fb = f(b);

    //Sprawdzamy, czy na krańcach przedziału [a,b] wartości funkcji mają różne znaki

    if (fa * fb > 0) cout << "BŁĄD!!! Funkcja nie ma różnych znaków na krańcach przedziału";
    else
    {
        result = true;

        // W pętli wyznaczamy kolejne przybliżenia pierwiastka
        while (true)
        {
            // Zwiększamy licznik obiegów pętli

            i++;

            // Wyznaczamy środek przedziału [a,b]

            x0 = (a + b) / 2;

            // Sprawdzamy, czy szerokość przedziału [a,b] jest mniejsza od dokładności

            if (fabs(a - x0) < epsx) break; // Jeśli tak, to kończymy

            // Obliczamy i zapamiętujemy wartość funkcji w punkcie x0

            fx = f(x0);

            // Sprawdzamy, czy wartość funkcji jest dostatecznie bliska zeru

            if (fabs(fx) < epsy) break; // Jeśli tak, to kończymy

            // Za nowy przedział [a,b] przyjmujemy tą z połówek [a,x0], [x0,b],
            // w której funkcja ma różne znaki na krańcach

            if (fa * fx < 0) b = x0;
            else
            {
                a = x0;
                fa = fx;
            }
        }
    }

    if (result) cout << "Pierwiastek        x0 = " << setw(18) << x0 << endl
        << "Wartość funkcji f(x0) = " << setw(18) << f(x0) << endl
        << "Dokładność dla x epsx = " << setw(18) << epsx << endl
        << "Dokładność dla y epsy = " << setw(18) << epsy << endl
        << "Liczba obiegów      i = " << i;

    cout << endl << endl;

    return 0;
}