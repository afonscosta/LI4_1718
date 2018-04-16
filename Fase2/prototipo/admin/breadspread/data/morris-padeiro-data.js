$(function() {

    Morris.Area({
        element: 'morris-area-chart',
        data: [{
            period: '2018-03-01',
            centeio: 20,
            mafra: 2,
            mistura: 8
        }, {
            period: '2018-03-02',
            centeio: 23,
            mafra: 4,
            mistura: 10
        }, {
            period: '2018-03-03',
            centeio: 19,
            mafra: 1,
            mistura: 14
        }, {
            period: '2018-03-04',
            centeio: 21,
            mafra: 3,
            mistura: 7
        }, {
            period: '2018-03-05',
            centeio: 30,
            mafra: 6,
            mistura: 17
        }, {
            period: '2018-03-06',
            centeio: 25,
            mafra: 4,
            mistura: 12
        }, {
            period: '2018-03-07',
            centeio: 28,
            mafra: 5,
            mistura: 9
        }, {
            period: '2018-03-08',
            centeio: 12,
            mafra: 9,
            mistura: 15
        }, {
            period: '2018-03-09',
            centeio: 10,
            mafra: 5,
            mistura: 17
        }, {
            period: '2018-03-10',
            centeio: 28,
            mafra: 8,
            mistura: 12
        }],
        xkey: 'period',
        ykeys: ['centeio', 'mafra', 'mistura'],
        labels: ['Pão de centeio', 'Pão de mafra', 'Pão de mistura'],
        pointSize: 2,
        hideHover: 'auto',
        resize: true
    });

    Morris.Donut({
        element: 'morris-donut-chart',
        data: [{
            label: "Subscrições Bronze",
            value: 21
        }, {
            label: "Subscrições Silver",
            value: 14
        }, {
            label: "Subscrições Gold",
            value: 7
        }, {
            label: "Encomendas ocasionais",
            value: 8
        }],
        resize: true
    });

    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: 'bijou de mistura',
            a: 85,
            b: 96
        }, {
            y: 'bola de centeio',
            a: 75,
            b: 65
        }, {
            y: 'pão c/ chourico',
            a: 50,
            b: 40
        }, {
            y: 'bola de centeio c/ sementes',
            a: 75,
            b: 65
        }, {
            y: 'bola de agua',
            a: 50,
            b: 40
        }, {
            y: 'bijou de mafra',
            a: 75,
            b: 65
        }, {
            y: 'bola de mistura',
            a: 100,
            b: 90
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['última semana', 'Esta semana'],
        hideHover: 'auto',
        resize: true
    });
    
});
