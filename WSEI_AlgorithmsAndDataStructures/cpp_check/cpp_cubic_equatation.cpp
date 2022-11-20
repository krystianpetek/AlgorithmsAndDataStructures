// Równanie sześcienne
// (C)2019 mgr Jerzy Wałaszek
// Metody numeryczne
//---------------------------

#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

// Tutaj definiujemy dane wejściowe
//----------------------------------
double epsy = 1e-12;  // Dokładność porównania z zerem
const double M_PI = 3.14159265358979323846;

// Funkcja rozwiązująca równanie sześcienne
// a,b,c,d - współczynniki wielomianu
//-----------------------------------------
void ce(double a, double b, double c, double d)
{
    double x1, x2, x3, p, q, delta;
    bool cmplx = false;     // Znacznik wyniku zespolonego

    cout << endl
        << "Równanie: "
        << a << " * x^3 + "
        << b << " * x^2 + "
        << c << " * x + "
        << d << " = 0" << endl;

    // Modyfikujemy współczynniki równania

    d /= a;
    c /= a;
    b /= a;
    a = b;
    b = c;
    c = d;

    // Obliczamy wyróżnik delta

    p = b - a * a / 3;
    q = 2 * a * a * a / 27 - a * b / 3 + c;
    delta = p * p * p / 27 + q * q / 4;

    // Sprawdzamy przypadki

    if (fabs(delta) < epsy) // 3 pierwiastki, 2 podwójne
    {
        q = ((q > 0) - (q < 0)) * pow(fabs(q) / 2, 1 / 3.0);
        x1 = -2 * q - a / 3;
        x2 = x3 = q - a / 3;
    }
    else if (delta > 0)    // 1 pierwiastek rzeczywisty, 2 zespolone
    {
        cmplx = true;     // Wynik zespolony
        q /= -2;
        delta = sqrt(delta);
        x1 = ((q + delta > 0) - (q + delta < 0)) * pow(fabs(q + delta), 1 / 3.0) +
            ((q - delta > 0) - (q - delta < 0)) * pow(fabs(q - delta), 1 / 3.0) - a / 3;

        // Schematem Hornera dzielimy wielomian równania sześciennego
        // przez dwumian x - x1

        double aa, bb, cc;

        aa = 1;
        bb = a + aa * x1;
        cc = b + bb * x1;

        // Obliczamy wyróżnik równania kwadratowego

        delta = bb * bb - 4 * aa * cc;

        delta = sqrt(-delta);

        x2 = -bb / 2 / aa; // Część rzeczywista
        x3 = delta / 2 / aa; // Część urojona
    }
    else  // 3 pierwiastki rzeczywiste
    {
        a /= 3;
        p = sqrt(-p);
        double pp = 2 / sqrt(3) * p;
        q = 3 * sqrt(3) * q / 2 / p / p / p;
        x1 = pp * sin(asin(q) / 3) - a;
        x2 = -pp * sin(asin(q) / 3 + M_PI / 3) - a;
        x3 = pp * cos(asin(q) / 3 + M_PI / 6) - a;
    }
    cout << "x1 = " << x1 << endl;
    if (cmplx) cout << "x2 = " << x2 << " + " << -x3 << "i" << endl
        << "x3 = " << x2 << " + " << x3 << "i";
    else      cout << "x2 = " << x2 << endl
        << "x3 = " << x3;
    cout << endl;
}

// Program główny
//---------------

int main()
{
    setlocale(LC_ALL, "");

    cout << fixed;
    cout << "Równania sześcienne typu" << endl
        << "  3    2" << endl
        << "ax + bx + cx + d = 0" << endl
        << "--------------------" << endl;

    //ce(5, 5, 5, 5);
    ce(9, 8, 7, 6);
    /*
    ce(1, 0, 0, 0);
    ce(1, 3, 3, 1);
    ce(1, -6, 12, -8);
    ce(1, 9, 27, 27);
    ce(1, -6, 11, -6);
    ce(1, -1, -16, -20);
    ce(1, -2, -10, -25);
    */

    cout << endl;

    return 0;
}