// Simples calculadora no terminal usando Node.js
const readline = require('readline');

// Criando interface para entrada de dados
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

// Mostrando as opções
console.log('*** Calculadora Simples ***');
console.log('Operações disponíveis: +  -  *  /');

// Perguntar o primeiro número
rl.question('Digite o primeiro número: ', function(num1) {
  // Perguntar o segundo número
  rl.question('Digite o segundo número: ', function(num2) {
    // Perguntar a operação
    rl.question('Escolha a operação: ', function(operacao) {
      const a = Number(num1);
      const b = Number(num2);
      let resultado;

      if (operacao === '+') {
        resultado = a + b;
      } else if (operacao === '-') {
        resultado = a - b;
      } else if (operacao === '*') {
        resultado = a * b;
      } else if (operacao === '/') {
        if (b !== 0) {
          resultado = a / b;
        } else {
          resultado = 'Erro: divisão por zero!';
        }
      } else {
        resultado = 'Operação inválida';
      }

      console.log(`Resultado: ${resultado}`);
      rl.close();
    });
  });
});
