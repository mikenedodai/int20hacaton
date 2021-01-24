
function buildChart(dateArray, chartData)
{
	let ctx = document.getElementById('myChart').getContext('2d');
	var myChart = new Chart(ctx, {
	    type: 'line',
	    data: {
	        labels: dateArray,
	        datasets: [{
	            label: '',
	            data: chartData,
	            borderWidth: 1
	        }]
	    },
	    options: {
	        scales: {
	            yAxes: [{
	                ticks: {
	                    beginAtZero: true
	                }
	            }]
	        }
	    }
	});
}

document.addEventListener('DOMContentLoaded', function(){
	
	let dateArray = ['21', '22', '23', '24', '25', '26'];
	let chartData = [20, 21, 19.9, 19.1, 22.5, 20];

	buildChart(dateArray, chartData);
});