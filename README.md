# Chess_game
 Projeto de jogo de xadrez completamente funcional
 
 ## Por quê?
 Este projeto faz parte do meu portfólio pessoal, com o objetivo de contribuir para meu crescimento e melhorar minhas habilidades de desenvolvedor.
 
 ## Recursos até o momento:
 
 v 0.1 - Implementações: 
 
- Criação da classe "Position" 

Técnicas de orientação a obejtos aplicadas:

- Encapsulamento
- Construtores
- Sobreposição

---------------------------------------------------

v 0.2 - Implementações:

- Criação da Enumeração "Color"
- Criação da Classe "Piece"
- Criação da Classe "GameBoard"
- Início da implementação do tabuleiro

Técnicas de orientação a obejtos aplicadas:

- Tipos enumerados
- Associações
- Encapsulamento

---------------------------------------------------

v 0.3 - Implementações:

- Criação da Classe "Screen"
- Início da implementação que exibe o tabuleiro

Técnicas de orientação a obejtos aplicadas:

- Elementos estáticos
- Encapsulamento

---------------------------------------------------

v 0.4 - Implementações:

- Criação da Classe "Chess"
- Iniciando a implementação das peças no tabuleiro (King/Tower)

Técnicas de orientação a obejtos aplicadas:

- Herança (King is a Piece/Tower is a Piece)
- Associações: Piece to GameChess( Um para um ) | GameChess to Piece (Um para vários)
- Construtor
- Base

---------------------------------------------------

v 0.5 - Implementações:

- Exceções personalizadas
- Criação da classe "ChessBoardExceptions"

Técnicas de orientação a obejtos aplicadas:

- Sobrecarga 
- Exceções

---------------------------------------------------

v 0.6 - Implementações:

- Criação da classe "ChessPositions"
- Conversão da orientação de uma matriz (número/número) para a orientação de um tabuleiro (letra/número).

Técnicas de orientação a obejtos aplicadas:

- Encapsulamento 
- Construtores
- Sobreposição (ToString)

---------------------------------------------------

v 0.7 : Implementações:

- Melhorando a impressão do tabuleiro

Técnicas de orientação a obejtos aplicadas:

- Elementos estáticos (Método "PrintPiece")

---------------------------------------------------

v 0.8 : Implementações:

- Criação da classe "ChessMatch"
- Início da implementação do método "PerformMove"
- Delegação da instânciação das peças para a classe "ChessMatch"
- Interação básica com o usuário
- Primeiros testes de movimentação das peças

Técnicas de orientação a obejtos aplicadas:

- Encapsulamento
- Elementos estáticos

---------------------------------------------------

v 0.9 : Implementações:

- Implementação de um método que avalia os possíveis movimentos de uma peça.
- Melhorias na classe "Screen", método "PrintGameBoard" e "PrintPiece".
- Melhorias na intrface de interação com o usuário no programa principal.

Técnicas de orientação a obejtos aplicadas:

- Classe abstrata
- Herança
- Sobreposição
- Sobrecarga

Estrutura de dados aplicada:

- Matriz

---------------------------------------------------

v 1.0 : Implementações:

- Implementação dos métodos "Move", "ValidateOrigin" e "ValidateDestiny" dentro da classe "ChessMatch".
- Implementação dos métodos "VerifyPossiblesMovments" e "CanMoveTo" dentro da classe "Piece".
- Melhorias na interface de interação com o usuário (Turno de cada jogador).
- Implementações de tratamento de exceções para movimentos inválidos das peças.

Técnicas de orientação a obejtos aplicadas:

- Encapsulamento.
- Exceções.

Técnicas de estrutura de dados utilizadas:

- Matriz.

---------------------------------------------------

v 1.1 : Implementações:

- Implementação dos métodos "PutNewPiece", "CapturedPieces" e "PieceInGame" dentro da classe "ChessMatch".
- Atualização do método "PerformMove" dentro da classe "ChessMatch".
- Implementação dos métodos "PrintMatch" e "PrintSet" dentro da classe "Screen".

Técnicas de orientação a obejtos aplicadas:

- Elementos estáticos

Técnicas de estrutura de dados utilizadas:

- Conjuntos.

---------------------------------------------------

v 1.2 : Implementações:

- Implementação da lógica de quando o Rei está em xeque. (O rei fica em xeque quando pelo menos uma peça adversária possui o alcance para capturá-lo com um movimento)
- Implementação dos métodos "Adversary", "King" e "VerifyCheck"  na classe "ChessMatch"
- Atualização da lógica dos métodos "Move" e "PerformMove" na classe "ChessMatch" (Foi implementada uma regra que impossibilita que o próprio jogador se coloque em xeque)
- Implementação do método "RollbackMove" na classe "ChessMatch" que desfaz o movimento quando o jogador se coloca em xeque.
- Implementado o método "MovementDecrement" na classe "Piece"
- Implementação da verificação de "Xeque" na classe Program.

Técnicas de orientação a obejtos aplicadas:

- Encapsulamento
- Operador "is" (Testa se um determinado objeto pertence a uma subclasse)
- Exceções

Técnicas de estrutura de dados utilizadas:

- Matrizes

---------------------------------------------------

v 1.3 : Implementações:

- Implementação da lógica de Xeque-Mate (Acontece quando não existe nenhum movimento possível para retirar o Rei da posição de xeque)
- Implementação do método "VerifyCheckmate" na classe "ChessMatch"
- Implementações na interface do jogador (Xeque e Xeque-Mate)

Técnicas de estrutura de dados utilizadas:

- Matrizes

---------------------------------------------------

v 1.4 : Implementações:

- Implementação de todas as peças restantes e suas regras de movimentação (Queen, Pawn, Bishop, Horse)
- Conclusão da mecânica base geral.

---------------------------------------------------

v 1.5 : Implementações:

- Implementando jogadas especiais: 

## "Roque/Castle" (Roque Grande/Roque Pequeno)

- Acontece quando quando o Rei move duas casas para a direita e a Torre move duas casas para a esquerda. Isso só é possível quando o Rei e a Torre ainda não se moveram e se as duas casas entre eles estiverem livres.
- Implementação realizada na classe "King"
- Atualização dos métodos "Move" e "PerformMove" para a jogada especial dentro da classe "ChessMatch"





