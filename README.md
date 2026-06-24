<div align="center">
  <img src="https://img.icons8.com/color/96/000000/algorithm.png" alt="Algorithm Logo" width="80"/>
  <h1>Análise e Complexidade de Algoritmos</h1>
  <p><b>Limite Inferior para Ordenação e Ordenação em Tempo Linear</b></p>

  [![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](#)
  [![C++](https://img.shields.io/badge/C%2B%2B-00599C?style=for-the-badge&logo=c%2B%2B&logoColor=white)](#)
  [![Status](https://img.shields.io/badge/Status-Concluído-success?style=for-the-badge)](#)
</div>

<br>

> **Instituição:** Instituto Federal de São Paulo (IFSP) - Campus Birigui <br>
> **Disciplina:** Análise e complexidade de algoritmos <br>
> **Atividade:** Grupo 4 - Limite Inferior para Ordenação e Ordenação em Tempo Linear <br>

---

## 👥 Equipe Desenvolvedora

**Arthur Christhopher Pires Dutra** - Bi3025616 <br>
**Diego Pires Goncalves** - B13025845 <br>
**Pedro Henrique Tamburi Sinhorini** - B13024555 <br>
**Raissa Santana da Silva** - Bi3024954 <br>

---

## 1. Fundamentos e Implementações

### 1.1 Limite Inferior para Ordenação
* Comprovou-se matematicamente, através do modelo de árvore binária de decisão, que algoritmos baseados em comparações possuem um limite que não pode ser superado: $\Omega(n \log n)$ comparações no pior cenário.
* O relatório distingue cota superior (foco no algoritmo específico) de cota inferior (teorema de impossibilidade focado em característica do próprio problema).

### 1.2 Ordenação em Tempo Linear (Não Comparativa)
Foram explorados e testados algoritmos que escapam da cota inferior tradicional:
* **Counting Sort:** Explora a estrutura de dados mapeando as memórias através da contagem de frequência de valores distintos. O tempo de execução é rigorosamente de $\Theta(n+k)$.
* **Radix Sort:** Organiza elementos processando dígitos individuais, partindo comumente do menos significativo (LSD). Atinge uma complexidade de tempo de $\Theta(d \cdot(n+k))$, com o bônus de processar dados sem sobrecarregar fortemente a memória desde que a quantidade de dígitos não seja demasiadamente grande.
* **Bucket Sort:** Reparte os elementos uniformemente em "baldes", chegando à ordenação interna de forma isolada e em um tempo otimizado médio de $O(n)$ caso a entrada seja distribuída uniformemente.

### 1.3 Aplicações Avançadas
* O repositório também inclui uma implementação robusta em C++ para a montagem de um Array de Sufixos (`SuffixArray.cpp`), que consome um algorítmo interno de Count Sort como base auxiliar para atingir o escalonamento ideal.

---

## Requisitos Analíticos e Objetivos

- [x] **Teoria e Limites:** Demonstração formal do limite de $\Theta(n \log n)$ como teto referencial.
- [x] **Implementação Prática:** Códigos limpos de `Counting Sort`, `Radix Sort` e `Bucket Sort` escritos em C# com bibliotecas padrão (`System.Diagnostics`).
- [x] **Estabilidade Analisada:** Avaliação sobre a preservação da mesma ordem relativa ao lidar com chaves repetidas em sub-rotinas.
- [x] **Engenharia de Desempenho:** Mensuração em milissegundos calculada através de laços de dez repetições contínuas, variando os arrays de entrada.
- [x] **Teste de Limite de Memória:** Análise da restrição de memória espacial dependente dos limitadores $(k)$ nas arquiteturas.

---

## Principais Cenários de Teste

Para validar as complexidades, as baterias de testes práticos consumiram tamanhos escalonados (1.000 a 1.000.000 de elementos) aplicados nas seguintes massas de dados:

1. **Vetor Aleatório:** * Massas geradas com dispersões aleatórias demonstrando o funcionamento de complexidade média.
2. **Vetor Ordenado:** * Massas previamente inseridas linearmente em ordem natural.
3. **Vetor Invertido:** * Conjunto contendo pior caso base estrutural.
4. **Vetor com Muitos Repetidos:** * Disposição onde a variação limite $k$ foi mínima, resultando no cenário onde algoritmos baseados em distribuição performaram nos tempos lineares com pico altíssimo de eficiência teórica.

---

## Estrutura do Repositório

```text
📁 algorithm-analysis-project
 ┣ 📜 BucketSort.cs                           # Implementação completa e cenários de Teste do Bucket Sort
 ┣ 📜 CountingSort.cs                         # Implementação completa e cenários de Teste do Counting Sort
 ┣ 📜 RadixSort.cs                            # Implementação completa e cenários de Teste do Radix Sort
 ┣ 📜 SuffixArray.cpp                         # Estudo de caso de Aplicação Avançada em C++
 ┗ 📜 Limite_Inferior_e_Ordenacao_Linear...pdf# Artigo Oficial: Cálculos, demonstrações formais e Análise temporal e Gráfica
