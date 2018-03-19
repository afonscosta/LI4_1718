# Requisitos de utilizador
	- Requisitos de sistema:
		- Requisitos funcionais.
		- Requisitos não funcionais.
		- Requisitos de domínio.

# Cada utilizador ter uma conta associada (Autenticação)
- registo do cliente
	- Dados necessários: nome, data de nascimento, morada...
	* formulário para registo de um cliente no sistema
- autenticação
- consulta dos dados pessoais
- alterar os dados pessoais da conta

# Pesquisa
- Inserção de novos produtos.
- Remoção de produtos.
- Alteração de produtos.
- Inserção de novas modalidades de subscrição.
- Remoção de subscrições.
- Alteração de subscrições.
- acesso a um catálogo com todos os produtos
- acesso a um catálogo dos serviços disponíveis (subscrições e entregas ocasionais)
	* descrição dos serviços
		$ bronze - o nível mais baixo, consiste em entregas entre as 6h e as 7h da manhã, todos os dias úteis e tem um custo semanal de 2€.
		$ prata - o nível intermédio, dá possibilidade ao cliente de receber os seus produtos duas vezes por dia, uma de manhã, entre as 6h e as 7h, e outra ao final do dia, entre as 19h e as 20h, com um custo semanal de 3,5€.
		$ ouro - o último nível, oferece ao cliente liberdade para escolher um intervalo de uma hora, duas vezes por dia, para poder receber os seus produtos em casa, todos os dias úteis, respeitando o horário de entregas, isto é, das 6h às 22h. Por um preço semanal de 5€ até 10 entregas, e com um custo adicional de 0,5€ por cada entrega extra.
		$ Se achar que não precisa de receber estes produtos duas vezes por dia, então pode optar por receber só ao final do dia em alguns dias e noutros só de manhã ou até as duas vezes, mas tal como já ficou definido não irá obter um desconto por isso e terá de pagar o mesmo preço.
- consulta das entregas confirmadas/pendentes
- consulta de contactos da empresa
- Consulta da história da empresa
- adicionar produto ao carrinho
- consulta do carrinho
	* mostrar preço por produto e quantidade
	* eliminar produtos
- consultar a produção do dia (padeiro)
- consultar as vendas da plataforma
- consultar estado de encomendas 
- consultar o percurso do estafeta (estimativa)
- consultar os dados dos clientes (dados pessoais)
- consultar dados das diversas subscrições

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

# Agendamento
- cancelar encomendas
	* se os artigos já se encontram confecionados, não é efetuado o reembolso
	* caso contrário, o montante é devolvido na plataforma
- confirmação via email/sms da viabilidade da entrega ocasional
- validar as encomendas ocasionais

# Realização
- finalizar produção (padeiro)
- consultar o percurso do dia
- inicializar percurso de entregas
	* acesso a informação do cliente no momento da entrega (morada, nome, observações)
	* finalizar entrega
		$ registo do estado de finalização de entrega (caixinha com o motivo)

# Cobrança e Recebimento
- pagamento online de subscrições e entregas ocasionais
- confirmação via email/sms do pagamento de uma entrega ocasional
- registo de pagamento ao estafeta de subscrições e entregas ocasionais
- emissão de fatura após o pagamento do serviço, via email e da sua referência via sms
