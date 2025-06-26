let pontuacaoTotal = 0, pontuacaoJogador1 = 0, pontuacaoJogador2 = 0, rodada = 0;

function gerarMatriz() {
    let matriz = Array.from({ length: 4 }, () => Array.from({ length: 4 }, () => Math.floor(Math.random() * 20) + 1));
    console.log("Matriz gerada:");
    matriz.forEach(linha => console.log(linha));
    return matriz;
}

function iniciarJogo(escolhaJogador1, escolhaJogador2) {
    if (![escolhaJogador1, escolhaJogador2].every(n => n >= 1 && n <= 16)) {
        console.warn("Escolha inválida. Jogadores devem escolher números entre 1 e 16.");
        return;
    }

    let matriz = gerarMatriz();
    let matrizSimples = matriz.flat();
    pontuacaoJogador1 += matrizSimples[escolhaJogador1 - 1];
    pontuacaoJogador2 += matrizSimples[escolhaJogador2 - 1];
    pontuacaoTotal = pontuacaoJogador1 + pontuacaoJogador2;
    rodada++;

    console.log(`Pontuação Atual: Jogador 1 = ${pontuacaoJogador1}, Jogador 2 = ${pontuacaoJogador2}, Total = ${pontuacaoTotal}`);

    if (rodada === 3) {
        let vencedor = pontuacaoJogador1 > pontuacaoJogador2 ? "Jogador 1" : pontuacaoJogador2 > pontuacaoJogador1 ? "Jogador 2" : "Empate";
        console.log(`Após ${rodada} rodadas, ${vencedor} venceu!`);
    }
}

// Simulação 
const readline = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

function perguntarRodada() {
    if (rodada < 3) {
        readline.question("Jogador 1, escolha um número entre 1 e 16: ", jogador1 => {
            readline.question("Jogador 2, escolha um número entre 1 e 16: ", jogador2 => {
                iniciarJogo(parseInt(jogador1), parseInt(jogador2));
                perguntarRodada();
            });
        });
    } else {
        console.log("Fim do jogo!");
        readline.close();
    }
}

perguntarRodada();
