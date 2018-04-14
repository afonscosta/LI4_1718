# Requisitos

- Requisitos de utilizador (RUi)
	- Requisitos de sistema: (RSi)
		- Requisitos funcionais.
		- Requisitos não funcionais.
		- Requisitos de domínio.

---

# Módulos

- Autenticação [AFONSO]
- Pesquisa [MARCO]
- Requisição [AFONSO]
- Realização [DANIEL]
- Cobrança e Recebimento [MARCO]
- Manutenção [DANIEL]

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
2. Registo do *cliente* deve ser efectuado com os seguintes dados: nome, data de nascimento, género, morada, NIF, contacto e email.
	1. Um formulário deve estar visível após a escolha do cliente em se registar.
	2. Após o preenchimento do registo o cliente deve confirmar a ação, sendo os dados de cada campo recolhidos e armazenados de imediato na base de dados.
	3. O sucesso ou insucesso da acção é comunicado ao cliente através de um popup.
	4. Caso a conta seja registada com sucesso, o cliente deve ficar automaticamente autenticado e com total acesso às funcionalidades do site.
	5. A morada será caracterizada pela rua, número de porta, freguesia, cidade e código postal.

## Funcionário
3. Registo do *funcionário* deve ser efetuado automaticamente pelo sistema considerando os seguintes dados: identificador do funcionário, nome, função, data de nascimento, contacto e morada.
	1. O registo dos funcionário deve ser efetuado pelo administrador do sistema.
	2. Deve ser dado como input um ficheiro JSON (.json) no seguinte formato:

	"funcionarios": [
		{ "idFunc":"E001", 
		  "nome":"Rogério Azevedo", 
		  "dataNasc":"1996/10/25", 
		  "contacto":"919999999", 
		  "morada":[ 
		  			 "rua":"Rua Flores de Cima", 
		  			 "numPorta":15, 
		             		 "codPostal":"4444-111",
					 "freg":"Gualtar",
		  			 "cidade":"Braga" 
				   ] },
		{ "idFunc":"P001", 
		  "nome":"Guilhermina", 
		  "dataNasc":"1981/04/13", 
		  "contacto":"911111111", 
		  "morada":[ 
		  			 "rua":"Rua Flores de Baixo", 
					 "numPorta":136, 
					 "codPostal":"5555-222", 
					 "freg":"Lamaçães",
					 "cidade":"Braga" 
				   ] }
	]

	3. O funcionário é caracterizado pela função que desempenha. Esta pode ser derivada com base no primeiro caractere do campo "idFunc". Assim sendo, existe duas categorias diferentes: estafeta (E) ou padeiro (P).
	4. O sistema deve fazer parse da informação e registar diretamente na BD todos os funcionários presentes no documento.
	5. O sucesso ou insucesso da acção é comunicado ao administrador através de um popup.

4. O utilizador deve estar autenticado para usufruir de todo e qualquer serviço disponibilizado.
5. O utilizador pode consultar os produtos e informações da empresa sem ter sessão iniciada.

---

# Pesquisa

## Cliente

1. O cliente deve ter acesso a um catálogo com todos os produtos comercializados e consequente descrição dos mesmos.
	1. Os produtos devem aparecer em formato de grelha com um número de colunas e linhas variáveis consoante o tamanho do ecrã do dispositivo que está a aceder ao website.
	2. Em cada célula deve estar presente uma imagem do produto, nome e o seu preço com IVA incluído.
	3. A seleção do produto deve apresentar ao cliente toda a informação do mesmo. Nomeadamente, um identificador, uma imagem, descrição completa, preço com IVA incluído, peso em gramas, lista dos ingredientes e tabela nutricional.
	
2. O cliente deve ter acesso a um catálogo com todos os serviços praticados. Desta forma, devem ser apresentadas a subscrição de bronze, prata, ouro e as entregas ocasionais (serviços oferecidos até à data de desenvolvimento do software Bread Spread).
	1. A subscrição *bronze* consiste em entregas entre as 6h e as 7h da manhã, todos os dias úteis e tem um custo semanal de *2€*.
	2. A subscrição *prata* consiste em entregas duas vezes por dia, uma de manhã, entre as 6h e as 7h, e outra ao final do dia, entre as 19h e as 20h, com um custo semanal de *3,5€*.
	3. A subscrição de *ouro* oferece ao cliente liberdade para escolher um intervalo de uma hora, duas vezes por dia, para receber os seus produtos em casa, todos os dias úteis. O preço semanal é de *5€*, com direito a um total de 10 entregas. Entregas adicionais tem um acrescento de 0.5€ por entrega.
	4. As subscrições apenas aceitam alterações no sentido de diminuir o número de vezes que o serviço é prestado. No entanto, não será realizado um desconto de acordo com tal alteração, pelo que o preço permanecerá o mesmo.
	5. As entregas ocasionais tem um acrescento ao preço total dos artigos de *2€*.
	6. Todo e qualquer serviço de entrega deve respeitar o horário de entregas, que se encontra determinado como sendo das 6h às 22h. 

3. O cliente deve poder consultar as encomendas que realizou, quer estas estejam confirmadas ou pendentes.
	1. Cada encomenda deve apresentar o seu código identificador, o estado (confirmada/pendente), a data de entrega, artigos solicitados.
	2. A informação das encomendas é carregada diretamente da BD e mostrada ao utilizador em formato de lista.
	3. A lista só é atualizada se o cliente recarregar a página.


4. O cliente deve poder consultar informação da empresa, como a sua história e contactos.
	1. A informação da empresa apenas pode ser alterada pelo administrador.
	2. Os dados são carregados da BD em texto e apresentados no site ao cliente quando este os solicita.

5. O cliente deve poder consultar uma página com todos os passos descrevendo o funcionamento dos serviços.
	1. A informação apenas pode ser alterada pelo administrador.
	2. Os dados são carregados da BD em texto e apresentados no site ao cliente quando este os solicita.

## Padeiro
6. O padeiro deve poder consultar a produção necessária em cada dia, ao longo de uma semana.
	1. É realizada uma query à BD e o resultado é apresentado ao padeiro em forma de lista.
	2. Cada elemento da lista tem informação como o nome do produto e a quantidade a confecionar.
	3. Cada elemento da lista representa um só artigo com a quantidade total a fabricar. Assim sendo, mesmo que o mesmo artigo esteja presente em várias encomendas, este aparece apenas uma vez com as quantidades somadas.
	4. As encomendas visíveis tem de estar confirmadas ou pendentes quando associadas a uma subscrição.

## Administrador
7. O administrador deve poder consultar dados sobre os diferentes serviços na Bread Spread. Nomeadamente as vendas da plataforma, estatísticas relacionadas com as subscrições dos diversos serviços e as quantidades vendidas de cada produto.
	1. Os dados serão apresentados utilizando um template de administração dos serviços disponíveis.
	2. De forma a popular o template os dados serão carregados da BD diretamente. Caso as informações se alterem, a página só muda quando atualizada. Nesse momento os dados serão extraídos novamente da BD e a página terá a informação mais recente.
	3. As vendas serão representadas por um gráfico de área. O eixo das abcissas representa cada semana com a respetiva quantidades de vendas dessa semana no eixo das ordenadas.
	4. As estatísticas relacionadas com as subscrições ativas dos clientes serão representadas por um diagrama circular. Cada um dos setores representará a percentegem de clientes que subscreveram o serviço em questão.
	5. As quantidades totais vendidas de cada produto serão representadas num gráfico de barras. Cada barra corresponderá a um único artigo.
	6. Nos diferentes dados presentes nesta página web, apenas entrarão as vendas que já tenham sido confirmadas ou realizadas. Desta forma, toda e qualquer encomenda pendente não será contemplada.

---

# Requisição

## Cliente
1. O cliente deve poder realizar subscrições nos diversos serviços disponibilizados.
	1. O sistema deverá apresentar em grelha os serviços disponíveis, bem como o respetivo preço e horários de entrega.
	2. Para novas subscrições de serviços, deverão ser indicados no formulário de adesão os dias e horas no qual devem ser feitas as entregas, caso o plano subscrito permita a escolha.
	3. Após a subscrição de um serviço este só entrará em vigor na semana seguinte.
	4. A subscrição é iniciada com o estado "ativa".
	
2. O *cliente* deve poder selecionar os dados guardados no seu perfil de utilizador para faturação, ou caso deseje, indicar outros. Deverá proceder-se do mesmo modo para a morada de entrega.

3. O *cliente* deve poder definir os produtos a serem entregues bem como as respetivas quantidades.
	
4. Para a requisição de entregas ocasionais, deverão ser indicados o dia e hora a que a entrega deve ser feita, a morada onde deve ser entregue, o NIF para faturação e os produtos que devem ser entregues, sendo sempre possível selecionar os dados guardados no perfil do cliente.
	1. O cliente deve poder requisitar uma entrega ocasional a qualquer momento do dia.
	2. A requisição de uma entrega ocasional terá de ser registada necessáriamente com  1h00 de antecedência até ao momento de entrega definido.
	3. A qualquer momento, antes de a entrega ocasional ser confirmada pelo administrador, a encomenda pode ser anulada.
	4. A encomenda pode tomar diferentes estados, nomeadamente, pendente, confirmada, confecionada, iniciou, proxima, entregue e falhada. Pendente quando é realizada pelo cliente. Confirmada quando o administrador a aceita. Confecionada quando o padeiro já realizou o artigo em questão. Iniciou quando o estafeta já indicou que iniciou o percurso de entrega das encomendas. Proxima quando o estafeta já declarou que a casa anterior no percurso já recebeu os seus produtos. Entregue quando esta já se encontra na posse do cliente. Falhada quando a entrega realizada pelo estafeta não foi concluída, isto é, o cliente não recebeu a encomenda.

5. O cliente deve poder usar o "carrinho" para guardar os artigos com o preço e respetivas quantidades que deseja comprar. Consequentemente, deve poder finalizar a compra quando tiver terminado.
	1. Quer no catálogo principal dos artigos, quer no popup com a informação detalhada de um determinado produto, deve ser possível adicionar esse mesmo produto ao carrinho de compras, com a respetiva quantidade especificada. Se nada for dito será adicionada uma quantidade unitária apenas.
	2. As informações associadas ao carrinho encontram-se guardadas enquanto o cliente tiver a sessão iniciada. Caso este termine sessão os dados presentes no carrinho são automaticamente apagados.
	3. Toda a informação que defina o carrinho encontra-se no lado do cliente e como tal não é registada no servidor.
	4. Os produtos podem ser removidos a qualquer momento, desde que ainda não tenha sido feito o "checkout" do carrinho.
	5. Toda e qualquer alteração ao estado do carrinho terá uma atualização imediata na estrutura de dados do carrinho guardada no lado do cliente.
	6. Ao finalizar a compra o cliente indica que a informação presente no carrinho pode ser registada e como tal esta é instanciada numa encomenda que será armazenada de forma a consolidar a ação do cliente.

6. A encomenda apenas será considerada válida se a morada definida para entrega pertencer à cidade de Braga.

7. O cliente que tenha uma subscrição ativa pode a qualquer momento agendar os produtos que deseja receber na semana seguinte. É considerado "segunda-feira" como primeiro dia da semana.
    1. O agendamento das entregas e respetivo pagamento tem ser feito até às 23h59min de domingo.
    2. O cliente pode agendar, nas horas estipuladas pela sua subscrição, a entrega de qualquer produto que seja fabricado pela empresa Bread Spread nas quantidades que desejar.
    3. No caso de uma encomenda ocasional, a  qualquer momento o cliente pode cancelar a sua encomenda. Caso os artigos ainda não tenham sido produzidos o cliente será reembolsado com saldo na plataforma, no valor da mesma.

8. O cliente recebe via email/sms assim que a sua encomenda é confirmada.

## Administrador
1. Todas as entregas ocasionais devem ser validadas pelo administrador.
	1. Uma entrega ocasional quando requisitada deve surgir num estado pendente.
	2. O administrador consoante a disponibilidade para a produção dos artigos para a data especificada, confirma ou não o pedido.
	3. Caso a encomenda seja aceite, esta passa a confirmada.
	4. Caso a encomenda seja rejeita, esta é eliminada do sistema.

---

# Realização

## Padeiro
1. O padeiro deve poder marcar como confecionadas as encomendas quando estas estiverem completas.
	1. A BD é atualizada para refletir o facto de que a encomenda está pronta a ser entregue.

## Estafeta
2. O estafeta poderá consultar a rota que tomará no dia em questão.
	1. O estafeta poderá visualizar as direções do percurso como um conjunto de diretivas ou no mapa.
	2. A rota gerada pela plataforma descreverá um percurso eficiente que passa por todos os clientes com subscrição.
	3. Caso uma entrega ocasional seja requerida durante a hora de entrega de uma subscrição, esta será também inserida na rota.
	
3. O estafeta deve marcar o seu percurso como inicializado ao partir da padaria.
	1. Haverá uma opção "Iniciar percurso" que, quando selecionada, atualizará o estatuto do estafeta e respetivas encomendas na BD.
	2. A opção "Iniciar percurso" apenas se disponibilizará no dia em questão.
	3. Igualmente, haverá uma opção "Finalizar percurso" que, quando selecionada, atualizará o estatuto do estafeta.
	4. A opção "Finalizar percurso" apenas se disponibilizará quando todas as entregas estiverem marcadas como finalizadas (quer seja por sucesso ou por caso de incapacidade de entrega).
	5. O estatuto do estafeta poderá tomar os seguintes valores: ativo, quando estiver a realizar entregas, ou inativo, quando não o estiver a fazer.

4. O estafeta deve ter acesso ao nome de cada cliente do percurso e a sua morada, bem como um contacto, caso o estafeta não receba resposta inicial do cliente no momento de entrega.
	1. Acesso à informação do cliente será restrita ao dia em questão enquanto o percurso estiver em curso e apenas quando o cliente em questão for o seguinte no percurso.
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
1. O *estafeta* deverá ter a possibilidade de registar pagamentos de encomendas ocasionais e de subscrições no sistema.
	1. Quando selecionada a entrega que será efetuada pelo *estafeta* no momento, deverá existir um campo de observações no qual estejam presentes dados relevantes do cliente ao qual será feita a entrega. A título exemplificativo, se esta for a última encomenda da semana será apresentado um lembrete de que o cliente deverá efetuar o pagamento do serviço da próxima semana.
	2. O estafeta confirma o pagamento do serviço, sendo gerada automaticamente a fatura. Esta é registada na BD, podendo ser acedida posteriormente.
	3. Após a confirmação do pagamento será apresentado um estado de sucesso ou insucesso da ação através de um popup.
	4. Para além da confirmação com o *estafeta*, o *cliente* deverá receber também via email/sms uma confirmação do registo de pagamento.
	5. O pagamento da primeira semana de uma determinada subscrição, deve ser realizado na primeira entrega dessa mesma semana.
	6. Os pagamentos realizados ao estafeta adjacentes a uma subscrição, são referentes às entregas da semana subsequente.
	7. Caso o cliente ainda não tenha escolhido os produtos que pretende para a semana seguinte aquando da última entrega da semana, deve ser informado que terá de realizar o pagamento online caso pretenda alterar o calendário/produtos da semana atual.
	8. O não pagamento adiantado do serviço prestado invalida a realização, e consequente entrega, do mesmo.

---

# Manutenção

## Cliente

1. O cliente poderá cancelar a sua subscrição a qualquer momento.
	1. A seleção desta opção deverá abrir um popup que informa o cliente de que perderá os benefícios da subscrição, sendo necessária a aprovação do cliente para que a ação seja consumada.
	2. O cliente terá a opção de cancelar as encomendas desta semana caso deseje. Caso contrário, o serviço deixará de ter efeito a partir da semana seguinte.
	3. Cancelando a subscrição imediatamente esta fico no estado "inativa". Caso apenas seja anulada no final da semana passa ao estado "última".

2. O cliente deve poder consultar os dados da sua conta pessoal e, consequentemente, poder altera-los.
	1. A informação pessoal aparece em formato formulário para que o cliente possa alterar.
	2. Após a alteração o cliente deve confirmar a ação carregando no botão para o efeito. Deste modo, os dados modificados são propagados e registados de imediato na BD.

4. O cliente deve poder demonstrar a sua satisfação perante a globalidade do serviço Bread Spread classificando-o de 1 a 5. A pontuação menor transparece um maior descontentamento com o serviço. No entanto a pontuação máxima revela uma satisfação total com o serviço prestado. 
	1. O cliente quando se regista tem a avaliação a 0. Esta significa que ainda não foi realizada nenhuma avaliação por parte do cliente.
	2. Caso o cliente já tenha avaliado anteriormente o serviço, este pode alterar a sua avaliação a qualquer momento.
	3. Apenas é mantido o registo da última avaliação feito do serviço.

5. O cliente deve poder desativar a sua conta.
	1. O perfil do cliente não é eliminado da BD.
	2. O estado do perfil é alterado para "desativado".


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

4. O administrador deve poder desativar as contas dos funcionários que já não trabalham na empresa.
	1. O perfil do funcionário é mantido na BD.
	2. O estado adjacente ao funcionário é alterado para "desativado".
