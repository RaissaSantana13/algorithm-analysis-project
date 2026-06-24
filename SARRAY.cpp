#include <iostream>
#include <vector>
#include <string>

using namespace std;

// --- A MÁQUINA DE ORDENAÇÃO: COUNTING SORT ESTÁVEL ---
// Esta função recebe a Fila atual (p) e os Crachás (c) e organiza a Fila em tempo O(N)
void count_sort(vector<int>& p, vector<int>& c) {
    int n = p.size();
    
    // 1. Conta quantas pessoas têm cada nota no crachá
    vector<int> cnt(n, 0);
    for (int x : c) {
        cnt[x]++;
    }

    // 2. Transforma a contagem em "Cadeiras Reservadas" (Soma de Prefixos)
    vector<int> pos(n);
    pos[0] = 0;
    for (int i = 1; i < n; i++) {
        pos[i] = pos[i - 1] + cnt[i - 1];
    }

    // 3. Posiciona cada elemento na cadeira certa, criando a nova fila ordenada
    vector<int> p_new(n);
    for (int x : p) {
        int i = c[x];        // Olha a nota do crachá
        p_new[pos[i]] = x;   // Senta na cadeira reservada
        pos[i]++;            // A próxima pessoa com a mesma nota senta na cadeira seguinte
    }
    p = p_new; // Atualiza a fila principal
}

int main() {
    // Desliga a sincronização com C para ler dados gigantes em milissegundos
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    string s;
    if (!(cin >> s)) return 0;

    // Adiciona a "parede de concreto" no final. O '$' tem peso 0 e evita erros.
    s += "$"; 
    int n = s.size();

    // p = Fila de posições (onde os sufixos começam)
    // c = Crachás de equivalência (as notas de cada pedaço)
    vector<int> p(n), c(n);

    // =======================================================
    // PASSO 0: ORDENAR APENAS 1 LETRA USANDO A TABELA ASCII
    // =======================================================
    
    // Conta a frequência de cada letra na Tabela ASCII (256 posições)
    vector<int> cnt_ascii(256, 0);
    for (int i = 0; i < n; i++) {
        cnt_ascii[s[i]]++;
    }
    
    // Reserva os assentos iniciais para as letras
    vector<int> pos_ascii(256, 0);
    for (int i = 1; i < 256; i++) {
        pos_ascii[i] = pos_ascii[i - 1] + cnt_ascii[i - 1];
    }
    
    // Coloca os índices iniciais na Fila (p)
    for (int i = 0; i < n; i++) {
        p[pos_ascii[s[i]]] = i;
        pos_ascii[s[i]]++;
    }

    // Distribui os primeiros Crachás (notas)
    c[p[0]] = 0; // O '$' sempre é o primeiro da fila e ganha nota 0
    for (int i = 1; i < n; i++) {
        // Se a letra for igual à de trás na fila, ganha a mesma nota (empate)
        if (s[p[i]] == s[p[i - 1]]) {
            c[p[i]] = c[p[i - 1]]; 
        } else {
            // Se for uma letra nova na fila, a nota aumenta
            c[p[i]] = c[p[i - 1]] + 1; 
        }
    }

    // =======================================================
    // PASSO K: O LAÇO PRINCIPAL (PREFIX DOUBLING)
    // =======================================================
    
    int k = 0;
    // O laço dobra a janela: 1, 2, 4, 8, 16... Isso garante o tempo O(log N)
    while ((1 << k) < n) {
        
        // TRUQUE DO DESLOCAMENTO: 
        // A metade direita já está ordenada. Puxamos a fila para trás pelo tamanho 
        // da janela para preparar a metade esquerda para a ordenação.
        // O "% n" garante que a leitura dê a volta na palavra como um círculo.
        for (int i = 0; i < n; i++) {
            p[i] = (p[i] - (1 << k) + n) % n;
        }

        // Ordena a metade esquerda de forma estável
        count_sort(p, c);

        // Atualizando os Crachás para a próxima janela (tamanho dobrado)
        vector<int> c_new(n);
        c_new[p[0]] = 0;
        
        for (int i = 1; i < n; i++) {
            // Forma o par de notas [Esquerda, Direita] da pessoa anterior na fila
            pair<int, int> prev = {c[p[i - 1]], c[(p[i - 1] + (1 << k)) % n]};
            
            // Forma o par de notas [Esquerda, Direita] da pessoa atual
            pair<int, int> now = {c[p[i]], c[(p[i] + (1 << k)) % n]};

            // Se os pares forem idênticos, as strings empataram de novo
            if (now == prev) {
                c_new[p[i]] = c_new[p[i - 1]];
            } else {
                // Se o par atual for maior, ganha uma nota nova (+1)
                c_new[p[i]] = c_new[p[i - 1]] + 1;
            }
        }
        
        // Salva os novos crachás e dobra o 'k'
        c = c_new; 
        k++;       
    }

    // =======================================================
    // IMPRESSÃO DA RESPOSTA
    // =======================================================
    
    // Começa do i = 1 para não imprimir a posição 0 (que é o sufixo vazio "$")
    for (int i = 1; i < n; i++) {
        cout << p[i] << "\n";
    }

    return 0;
}