#include <iostream>
#include <windows.h>
#include <string>
#include <conio.h>

using namespace std;

// Definições de cores (Padrão Windows)
enum Color {
    BLACK = 0, BLUE = 1, GREEN = 2, CYAN = 3, RED = 4,
    MAGENTA = 5, YELLOW = 6, WHITE = 7, GRAY = 8, LIGHT_MAGENTA = 13
};

// Configura a cor do texto e do fundo
void setStyle(int back, int fore) {
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(h, (back << 4) | fore);
}

// Move o cursor para X e Y
void pos(int x, int y) {
    COORD c = { (SHORT)x, (SHORT)y };
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
}

// Desenha uma janela estilo Sulfoxido
void drawWindow(int x, int y, int w, int h, string title) {
    setStyle(BLACK, LIGHT_MAGENTA);
    // Topo
    pos(x, y); cout << (char)201 << string(w - 2, (char)205) << (char)187;
    pos(x + (w / 2) - (title.length() / 2), y); cout << " " << title << " ";
    // Laterais
    for (int i = 1; i < h; i++) {
        pos(x, y + i); cout << (char)186;
        pos(x + w - 1, y + i); cout << (char)186;
    }
    // Base
    pos(x, y + h); cout << (char)200 << string(w - 2, (char)205) << (char)188;
}

// Desenha um botão/tile
void drawTile(int x, int y, string label, string key) {
    setStyle(LIGHT_MAGENTA, BLACK);
    pos(x, y);     cout << "             ";
    pos(x, y + 1); cout << " [" << key << "] " << label;
    pos(x + 12, y + 1); cout << " ";
    pos(x, y + 2); cout << "             ";
    setStyle(BLACK, WHITE);
}

void renderDesktop() {
    system("cls");
    // Barra de Tarefas Superior
    setStyle(LIGHT_MAGENTA, WHITE);
    pos(0, 0);
    cout << " SULFOXIDO OS v1.0.5 | KERNEL: C++ NATIVE | STATUS: STABLE             " << endl;

    // Desenha a Moldura Principal
    drawWindow(2, 2, 76, 22, " SULF-DASHBOARD ");

    // Grid de Aplicativos (Tiles)
    drawTile(6, 5, "ARQUIVOS", "1");
    drawTile(22, 5, "NOTAS", "2");
    drawTile(38, 5, "CALC", "3");
    drawTile(54, 5, "RELOGIO", "4");

    drawTile(6, 10, "TERMINAL", "5");
    drawTile(22, 10, "TEMAS", "6");
    drawTile(38, 10, "CONFIG", "7");
    drawTile(54, 10, "SAIR", "X");

    // Rodapé de Logs
    setStyle(BLACK, GRAY);
    pos(4, 21); cout << "Log: HelioFS montado em /root. Aguardando instrucao...";
    setStyle(BLACK, WHITE);
    pos(4, 25); cout << "Pressione a tecla correspondente: ";
}

int main() {
    // Ajusta o tamanho do console e título
    system("title SulfoxidoOS v1.0.5");
    system("mode con: cols=81 lines=30");

    while (true) {
        renderDesktop();

        char input = toupper(_getch());

        switch (input) {
        case '1': system("explorer ."); break;
        case '2': system("notepad.exe"); break;
        case '3': system("calc.exe"); break;
        case '4':
            pos(4, 23); setStyle(BLACK, YELLOW);
            system("date /t & time /t");
            _getch();
            break;
        case '5':
            system("cls");
            setStyle(BLACK, LIGHT_MAGENTA);
            system("cmd /k prompt Sulfoxido-Shell$G");
            break;
        case 'X':
            return 0;
        }
    }
    return 0;
}