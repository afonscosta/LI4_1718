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
- Manutenção

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

3. O cliente deve poder consultar as encomendas que realizou, quer estas estejam confirmadas ou pendentes.
	1. Cada encomenda deve apresentar o seu código identificador, o estado (confirmada/pendente), a data de entrega, artigos solicitados.
	2. A informação das encomendas é carregada diretamente da BD e mostrada ao utilizador em formato de lista.
	3. A lista só é atualizada se o cliente recarregar a página.

4. O cliente deve poder consultar os dados da sua conta pessoal e, consequentemente, poder altera-los.
	1. A informação pessoal aparece em formato formulário para que o cliente possa alterar.
	2. Após a alteração o cliente deve confirmar a ação carregando no botão para o efeito. Deste modo, os dados modificados são propagados e registados de imediato na BD.

5. O cliente deve poder consultar informação da empresa, como a sua história e contactos.
	1. A informação da empresa apenas pode ser alterada pelo administrador.
	2. Os dados são carregados da BD em texto e apresentados no site ao cliente quando este os solicita.

6. O cliente deve poder consultar uma página com todos os passos descrevendo o funcionamento dos serviços.
	1. A informação apenas pode ser alterada pelo administrador.
	2. Os dados são carregados da BD em texto e apresentados no site ao cliente quando este os solicita.

## Padeiro
7. O padeiro deve poder consultar a produção necessária em determinado dia.
	1. A pesquisa é feita com base num ano, mês e dia específicos.
	2. É realizada uma query à BD e o resultado é apresentado ao padeiro em forma de lista.
	3. Cada elemento da lista tem informação como o nome do produto e a quantidade a confecionar.
	4. Cada elemento da lista representa um só artigo com a quantidade total a fabricar. Assim sendo, mesmo que o mesmo artigo esteja presente em várias encomendas, este aparece apenas uma vez com as quantidades somadas.

## Administrador
8. O administrador deve poder consultar dados sobre os diferentes serviços na Bread Spread. Nomeadamente as vendas da plataforma, estatísticas relacionadas com as subscrições dos diversos serviços e as quantidades vendidas de cada produto.
	1. Os dados serão apresentados utilizando um template do bootstrap intitulado "SB Admin".
	2. De forma a popular o bootstrap os dados serão carregados da BD diretamente. Caso as informações se alterem, a página só muda quando atualizada. Nesse momento os dados serão extraídos novamente da BD e a página terá a informação mais recente.
	3. As vendas serão representadas por um gráfico de área. O eixo das abcissas representa cada semana com a respetiva quantidades de vendas dessa semana no eixo das ordenadas.
	4. As estatísticas relacionadas com as subscrições dos clientes serão representadas por um diagrama circular. Cada um dos setores representará a percentegem de clientes que subscreveram o serviço em questão.
	5. As quantidades vendidas de cada produto serão representadas num gráfico de barras. Cada barra corresponderá a um único artigo.
	6. Nos diferentes dados presentes nesta página web, apenas entrarão as vendas que já tenham sido confirmadas ou realizadas. Desta forma, toda e qualquer encomenda pendente não será contemplada.

- consultar estado de encomendas (?)

## Cliente e Administrador [Faz mais sentido estar na realização]
10. Tanto o cliente como o administrador devem poder consultar uma estimativa da posição do estafeta durante o seu percurso.
	1. ...

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

---

# Cobrança e Recebimento
- pagamento online de subscrições e entregas ocasionais
- confirmação via email/sms do pagamento de uma entrega ocasional
- registo de pagamento ao estafeta de subscrições e entregas ocasionais
- emissão de fatura após o pagamento do serviço, via email e da sua referência via sms

---

# Manutenção
- Inserção de novos produtos.
- Remoção de produtos.
- Alteração de produtos.
- Inserção de novas modalidades de subscrição.
- Remoção de subscrições.
- Alteração de subscrições.

