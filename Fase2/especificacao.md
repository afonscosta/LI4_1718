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

3. consulta das entregas confirmadas/pendentes

- consulta dos dados pessoais & alterar os dados pessoais da conta

- consulta de contactos da empresa & Consulta da história da empresa (info da empresa)

- consultar a produção do dia (padeiro)
- consultar as vendas da plataforma
- consultar estado de encomendas 
- consultar o percurso do estafeta (estimativa)
- consultar os dados dos clientes (dados pessoais)
- consultar dados das diversas subscrições

---

# Requisição
1. O cliente deve ter disponível para preencher um formulário onde possa especificar todos os dados necessários para requisitar uma entrega ocasional (ou outro tipo de entregas).
    1. Este formulário é apresentado para ser preenchido no momento em que um cliente se regista mas pode ser acedido em qualquer momento.
    2. Os dados do formulário podem ser alterados a qualquer momento.
	3. O cliente pode requisitar uma entrega ocasional a qualquer momento do dia.
    4. Os dados que têm de ser especificados para uma entrega ocasional são: o dia e a hora a que a entrega deve ser feita, a morada onde deve ser entregue, o NIF para faturação e os produtos que devem ser entregues.
    5. O cliente deve conseguir escolher usar os seus dados da faturação ou inserir novos.
    6. O cliente deve conseguir escolher usar a sua morada ou inserir outra para a realização da entrega.
    7. A entrega ocasional tem de ser feita com pelo menos 1h00 de antecedência.
    8. A qualquer momento, antes de a entrega ocasional ser confirmada pelo administrador, a encomenda pode ser anulada.
3. O cliente pode a qualquer momento assinar uma subscrição de qualquer tipo.
	1. O cliente tem de estar registado no sistema.
	2. No momento de fazer uma nova subscrição o cliente escolhe uma das três opções disponíveis.
	3. No formulário de inscrição numa subscrição, o cliente escolhe se quer usar a morada que está associada à sua conta ou uma nova, para a realização da entrega.
	4. No formulário de inscrição numa subscrição, o cliente escolhe se quer usar a informação para faturação que está associada à sua conta ou uma nova.
	5. Após a subscrição de um serviço este só entre em vigor na semana seguinte.
4. [COLOCAR COISAS DO CARRINHO DA PESQUISA]

---

# Agendamento 
1. O cliente que tenha uma subscrição ativa pode a qualquer momento agendar os produtos que deseja receber na semana seguinte. É considerado "segunda" como primeiro dia da semana.
    1. O agendamento das entregas e respetivo pagamento tem ser feito até às 23h59min de domingo.
    2. O cliente pode agendar, nas horas estipuladas pela sua subscrição, a entrega de qualquer produto que seja fabricado pela empresa Bread Spread nas quantidades que desejar.
    3. Em qualquer momento o cliente pode cancelar a sua encomenda. Caso os artigos ainda não tenham sido produzidos o cliente será reembolsado com saldo na plataforma, no valor da mesma.
2. O cliente recebe via email/sms assim que a sua encomenda é confirmada.
3. Todas as entregas ocasionais devem ser validadas pelo administrador.
	1. Uma entrega ocasional quando requisitada deve surgir num estado pendente.
	2. O administrador consoante a disponibilidade para a produção dos artigos para a data especificada, confirma ou não o pedido.
	3. Caso a encomenda seja aceite, esta passa a confirmada.

---

# Realização

1. O padeiro deve poder marcar como confecionadas as encomendas quando estas estiverem completas.
	1. A BD é atualizada para refletir o facto de que a encomenda está pronta a ser entregue.
	
2. O estafeta poderá consultar a rota que tomará no dia em questão.
	1. O estafeta poderá visualizar as direções do percurso como um conjunto de diretivas ou no mapa.
	2. A rota gerada pela plataforma descreverá um percurso eficiente que passa por todos os clientes com subscrição.
	3. Caso uma entrega ocasional seja requerida durante a hora de entrega de uma subscrição, esta será também inserida na rota.
	
3. O estafeta deve marcar o seu percurso como inicializado ao partir da padaria.
	1. Haverá uma opção "Iniciar roteiro" que, quando selecionada, atualizará o estatuto do estafeta e respetivas encomendas na BD.
	2. A opção "Iniciar roteiro" apenas se disponibilizará no dia em questão.
	3. Igualmente, haverá uma opção "Finalizar roteiro" que, quando selecionada, atualizará o estatuto do estafeta.
	4. A opção "Finalizar roteiro" apenas se disponibilizará quando todas as entregas estiverem marcadas como finalizadas (quer seja por sucesso ou por caso de incapacidade de entrega).

4. O estafeta deve ter acesso ao nome de cada cliente do percurso e a sua morada, bem como um contacto, caso o estafeta não receba resposta inicial do cliente no momento de entrega.
	1. Acesso à informação do cliente será restrita ao dia em questão enquanto o roteiro estiver em curso e apenas quando o cliente em questão for o seguinte no roteiro.
	2. No momento em que a entrega de um dado cliente for completa, o acesso à sua informação será revogado.

5. No momento de entrega, o estafeta preencherá um pequeno formulário no qual especificará se a entrega foi bem sucedida. Adicionalmente, poderá acrescentar observações relativas à mesma.
	1. Caso a entrega seja bem sucedida, especificar-se-á o método de pagamento.
	2. Caso contrário, informar-se-á que a entrega não pôde ser feita e porquê.

---

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

# Manutenção

## Cliente

1. O cliente poderá alterar a sua subscrição a qualquer momento.
	1. O cliente poderá mudar entre subscrição *bronze, prata* e *ouro* consoante os seus desejos.
	2. A alteração tomará efeito apenas na semana seguinte.
	3. Caso sejam realizadas alterações numa subscrição, estas apenas ficam vigentes enquanto o serviço estiver ativo. A partir do momento em que o cliente o cancela, as suas preferências não serão guardadas.
	
2. O cliente poderá cancelar a sua subscrição a qualquer momento.
	1. A seleção desta opção deverá abrir um popup que informa o cliente de que perderá os benefícios da subscrição, sendo necessária a aprovação do cliente para que a ação seja consumada.
	2. O cliente terá a opção de cancelar as encomendas desta semana caso deseje. Caso contrário, o serviço deixará de ter efeito a partir da semana seguinte.


## Administrador
1. O administrador deve poder inserir novos produtos para venda na plataforma.
	1. A informação do produto a inserir inclui nome, descrição, preço, imagem, ingredientes e informação nutricional.
	2. A informação será guardada num objeto *produto* e como tal não será imediatemente guardada na BD.
	3. Os produtos adicionados serão apresentados em formato de lista como forma de verificação dos dados introduzidos.
	4. Ao submeter os novos produtos, estes serão registados na BD, ficando de imediato acessíveis.

2. O administrador deve poder alterar informação relativa a produtos existentes para venda na plataforma.
	1. A informação relativa ao produto que pretende alterar é carregada da BD para um objeto *produto* local.
	2. O administrador poderá mudar qualquer informação que considere relevante.
	3. Ao submeter as alterações, as mudanças são registadas na BD e, consequentemente, na apresentação do produto na plataforma.

3. O administrador deve poder remover produtos de venda da plataforma.
	1. A seleção desta opção deverá abrir um popup, que informa o administrador de que a informação relativa ao produto será apagada permanentemente, questionando se tem a certeza que o deseja fazer.

