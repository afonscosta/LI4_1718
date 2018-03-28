# Requisitos

- Requisitos de utilizador (RUi)
	- Requisitos de sistema: (RSi)
		- Requisitos funcionais.
		- Requisitos não funcionais.
		- Requisitos de domínio.

---

# Módulos

- Autenticação
- Pesquisa
- Requisição
- Agendamento
- Realização
- Cobrança e Recebimento
- Conta (?)
- Manutenção (?)
- Empresa (?)

---

# Glossário

*Utilizador: cliente, estafeta, padeiro e administrador*

*Funcionário: estafeta e padeiro*

*Subscrição: bronze, prata e ouro*

*Serviço: subscrição bronze, subscrição prata, subscrição ouro e entrega ocasional*

---

# Autenticação

1. Todos os utilizadores tem de ter uma conta associada.

## Cliente
2. Registo do *cliente* deve ser efectuado com os seguintes dados: nome, data de nascimento, morada, género e email.
	1. Um formulário deve estar visível após a escolha do cliente em se registar.
	2. Após o preenchimento do registo o cliente deve confirmar a ação, sendo os dados de cada campo recolhidos e armazenados de imediato na base de dados.
	3. O sucesso ou insucesso da acção é comunicado ao cliente através de um popup.
	4. Caso a conta seja registada com sucesso, o cliente deve ficar automaticamente autenticado e com total acesso às funcionalidades do site.

## Funcionário
3. Registo do *funcionário* deve ser efetuado automaticamente pelo sistema considerando os seguintes dados: identificador do funcionário, nome, função, data de nascimento, contacto e morada.
	1. O registo dos funcionário deve ser efetuado pelo administrador do sistema.
	2. Deve ser dado como input um ficheiro JSON (.json) no seguinte formato:

	"funcionarios": [
		{ "idFunc":"E001", 
		  "nome":"Rogério Azevedo", 
		  "funcao":"E", 
		  "dataNasc":"1996/10/25", 
		  "contacto":"919999999", 
		  "morada":[ 
		  			 "rua":"Rua Flores de Cima", 
		  			 "numPorta":15, 
		             "codPostal":"4444-111", 
		  			 "cidade":"Braga" 
				   ] },
		{ "idFunc":"P001", 
		  "nome":"Guilhermina", 
		  "funcao":"P", 
		  "dataNasc":"1981/04/13", 
		  "contacto":"911111111", 
		  "morada":[ 
		  			 "rua":"Rua Flores de Baixo", 
					 "numPorta":136, 
					 "codPostal":"5555-222", 
					 "cidade":"Braga" 
				   ] }
	]

	3. O sistema deve fazer parse da informação e registar diretamente na BD todos os funcionários presentes no documento.
	4. O sucesso ou insucesso da acção é comunicado ao administrador através de um popup.

4. O utilizador deve estar autenticado para usufruir de todo e qualquer serviço disponibilizado.
5. O utilizador pode consultar os produtos e informações da empresa sem ter sessão iniciada.

---

# Pesquisa

## Cliente

1. O cliente deve ter acesso a um catálogo com todos os produtos comercializados e consequente descrição dos mesmos.
	1. Os produtos devem aparecer em formato de grelha com um número de colunas e linhas variáveis consoante o tamanho do ecrã do dispositivo que está a aceder ao website.
	2. Em cada célula deve estar presente uma imagem do produto, nome e o seu preço com IVA incluído.
	3. A seleção do produto deve abrir um popup com toda a informação deste. Nomeadamente, uma imagem, descrição completa, preço com IVA incluído, peso, lista dos ingredientes e tabela nutricional.
	
2. O cliente deve ter acesso a um catálogo com todos os serviços praticados. Desta forma, devem ser apresentadas a subscrição de bronze, prata, ouro e as entregas ocasionais (serviços oferecidos até à data de desenvolvimento do software Bread Spread).
	1. A subscrição *bronze* consiste em entregas entre as 6h e as 7h da manhã, todos os dias úteis e tem um custo semanal de 2€.
	2. A subscrição *prata* consiste em entregas duas vezes por dia, uma de manhã, entre as 6h e as 7h, e outra ao final do dia, entre as 19h e as 20h, com um custo semanal de 3,5€.
	3. A subscrição de *ouro* oferece ao cliente liberdade para escolher um intervalo de uma hora, duas vezes por dia, para receber os seus produtos em casa, todos os dias úteis. O preço semanal é de 5€, com direito a um total de 10 entregas. Entregas adicionais tem um acrescento de 0.5€ por entrega.
	4. As subscrições apenas aceitam alterações no sentido de diminuir o número de vezes que o serviço é prestado. No entanto, não será realizado um desconto de acordo com tal alteração, pelo que o preço permanecerá o mesmo.
	5. As entregas ocasionais tem um acrescento ao preço normal dos artigos de *X.XX€*.
	6. Todo e qualquer serviço de entrega deve respeitar o horário de entregas, que se encontra determinado como sendo das 6h às 22h. 

3. O cliente deve poder usar o "carrinho" para guardar os artigos com o preço e respetivas quantidades que deseja comprar. Consequentemente, deve poder finalizar a compra quando tiver terminado.
	1. Quer no catálogo principal dos artigos, quer na popup com a informação detalhada de um determinado produto, deve ser possível adicionar esse mesmo produto ao carrinho de compras, com a respetiva quantidade especificada. Se nada for dito será adicionada uma quantidade unitária apenas.
	2. O cliente pode remover qualquer produto associado ao carrinho.
	3. As informações associadas ao carrinho encontram-se guardadas enquanto o cliente tiver a sessão iniciada. Caso este termine sessão os dados presentes no carrinho são automaticamente apagados.
	4. Toda a informação que defina o carrinho encontra-se num objeto "encomenda" e como tal não é armazenada diretamente na BD sempre que existe alguma mudança.
	4. Toda e qualquer alteração ao estado do carrinho terá uma atualização imediata no objeto encomenda correspondente aquela sessão.
	5. Ao finalizar a compra o cliente indica que a informação presente no carrinho pode ser registada e como tal o objeto "encomenda" inserido na BD de forma a consolidar a ação do cliente.

3. consulta das entregas confirmadas/pendentes

- consultar a produção do dia (padeiro)
- consultar as vendas da plataforma
- consultar estado de encomendas 
- consultar o percurso do estafeta (estimativa)
- consultar os dados dos clientes (dados pessoais)
- consultar dados das diversas subscrições

---

# Requisição
- formulário para uma entrega ocasional ( dia, hora, morada, NIF)
	* perguntar se os dados de faturação são os já presentes na conta
	* perguntar se quer utilizar os dados da conta para a entrega
- alteração dos dados referentes a uma subscrição
- subscrição do serviço bronze/prata/ouro
	* formulário para a subscrição de um serviço
		$ perguntar se quer utilizar os dados da conta para a entrega
		$ perguntar se os dados de faturação são os já presentes na conta
- Checkout do carrinho

---

# Agendamento
- cancelar encomendas
	* se os artigos já se encontram confecionados, não é efetuado o reembolso
	* caso contrário, o montante é devolvido na plataforma
- confirmação via email/sms da viabilidade da entrega ocasional
- validar as encomendas ocasionais

---

# Realização
- finalizar produção (padeiro)
- consultar o percurso do dia
- inicializar percurso de entregas
	* acesso a informação do cliente no momento da entrega (morada, nome, observações)
	* finalizar entrega
		$ registo do estado de finalização de entrega (caixinha com o motivo)

# Cobrança e Recebimento

## Cliente
1. O *cliente* deverá ter disponível na sua área de cliente a opção de efetuar pagamentos dos seus serviços via web.
	1. Quando selecionada pelo *cliente* a opção de pagamento via web, deverá ser apresentada uma lista dos serviços que ainda não se encontram pagos.
	2. Deverá ser dada a opção ao *cliente* a opção de seleção de vários serviços para pagamento.
	3. Após serem selecionados os serviços a pagar, deverá ser apresentado ao *cliente* um formulário onde este deverá introduzir os dados de pagamento.
	4. Após o preenchimento do formulário, o *cliente* deverá confirmar que deseja efetuar o pagamento selecionando a opção *Pagar*, sendo apresentado de seguida o estado de sucesso ou insucesso da ação.
	5. Para além da confirmação via web, o sistema deverá enviar ao cliente um email/sms de confirmação de receção do pagamento com as referências associadas à transação.

## Estafeta
1. O *estafeta* deverá ter a possibilidade de registar pagamentos de encomendas ocasionais e de subscrições no sistema. (feitos pessoalmente)
	1. Quando selecionada a entrega que será efetuada pelo *estafeta* no momento, deverá existir um campo de observações no qual estejam presentes dados relevantes do cliente ao qual será feita a entrega. A título exemplificativo, se esta for a última encomenda da semana será apresentado um lembrete de que o cliente deverá efetuar o pagamento do serviço da próxima semana.
	2. O estafeta confirma o pagamento do serviço, sendo gerada automaticamente a fatura. Esta é registada na BD, podendo ser acedida posteriormente.
	3. Após a confirmação do pagamento será apresentado um estado de sucesso ou insucesso da ação através de um popup.
	4. Para além da confirmação com o *estafeta*, o *cliente* deverá receber também via email/sms uma confirmação do registo de pagamento.

---

# Conta
- consulta dos dados pessoais
- alterar os dados pessoais da conta

---

# Manutenção
- Inserção de novos produtos.
- Remoção de produtos.
- Alteração de produtos.
- Inserção de novas modalidades de subscrição.
- Remoção de subscrições.
- Alteração de subscrições.

---

# Empresa (Informação estática no site)
- consulta de contactos da empresa
- Consulta da história da empresa











# RASCUNHOS

	1. Os produtos devem aparecer em formato de grelha com 2/3 colunas e com um número ilimitado de linhas. *TALVEZ SEJA TRATADO PELO BOOTSTRAP*
		+----+----+				+----+----+----+
		| P1 | P2 |				| P1 | P2 | P3 |
		+----+----+				+----+----+----+
		| P3 | P4 |				| P4 | P5 | P6 |
		+----+----+		 OU		+----+----+----+	ESCOLHER!
		| P5 | P6 |				| P7 | P8 | P9 |
		+----+----+				+----+----+----+
		| .. | .. |				| .. | .. | .. |
		+----+----+				+----+----+----+
