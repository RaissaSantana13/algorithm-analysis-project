#include <iostream>
#include <vector>
#include <string>

using namespace std;

void count_sort(vector<int>& p, vector<int>& c) {
    int n = p.size();
    vector<int> cnt(n, 0);

    for (int x : c) {
        cnt[x]++;
    }

    vector<int> pos(n);
    pos[0] = 0;
    for (int i = 1; i < n; i++) {
        pos[i] = pos[i - 1] + cnt[i - 1];
    }

    vector<int> p_new(n);
    for (int x : p) {
        int i = c[x];
        p_new[pos[i]] = x;
        pos[i]++;
    }
    p = p_new;
}

int main() {
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    string s;
    if (!(cin >> s)) return 0;

    s += "$"; 
    int n = s.size();

    vector<int> p(n), c(n);

    vector<int> cnt_ascii(256, 0);
    for (int i = 0; i < n; i++) {
        cnt_ascii[s[i]]++;
    }
    
    vector<int> pos_ascii(256, 0);
    for (int i = 1; i < 256; i++) {
        pos_ascii[i] = pos_ascii[i - 1] + cnt_ascii[i - 1];
    }
    
    for (int i = 0; i < n; i++) {
        p[pos_ascii[s[i]]] = i;
        pos_ascii[s[i]]++;
    }

    c[p[0]] = 0;
    for (int i = 1; i < n; i++) {
        if (s[p[i]] == s[p[i - 1]]) {
            c[p[i]] = c[p[i - 1]]; 
        } else {
            c[p[i]] = c[p[i - 1]] + 1; 
        }
    }

    int k = 0;
    while ((1 << k) < n) {
        
        for (int i = 0; i < n; i++) {
            p[i] = (p[i] - (1 << k) + n) % n;
        }

        count_sort(p, c);

        vector<int> c_new(n);
        c_new[p[0]] = 0;
        for (int i = 1; i < n; i++) {

            pair<int, int> prev = {c[p[i - 1]], c[(p[i - 1] + (1 << k)) % n]};
            pair<int, int> now = {c[p[i]], c[(p[i] + (1 << k)) % n]};

            if (now == prev) {
                c_new[p[i]] = c_new[p[i - 1]];
            } else {
                c_new[p[i]] = c_new[p[i - 1]] + 1;
            }
        }
        
        c = c_new; 
        k++;       
    }

    for (int i = 1; i < n; i++) {
        cout << p[i] << "\n";
    }

    return 0;
}
