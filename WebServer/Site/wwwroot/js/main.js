﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function buildChart(dateArray, chartData) {
	let ctx = document.getElementById('myChart').getContext('2d');
	var myChart = new Chart(ctx, {
		type: 'line',
		data: {
			labels: dateArray,
			datasets: [{
				label: '',
				data: chartData,
				borderWidth: 1,
				backgroundColor: "#a7572b"
			}]
		},
		options: {
			legend: {
				display: false
			},
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

document.addEventListener('DOMContentLoaded', () => process());

async function process() {
	let imgs = document.getElementsByClassName("buckwheat-image");
	let heightStandard = imgs[0].height;

	for (i = 0; i < imgs.length; i++) {
		imgs[i].height = heightStandard;
	}

	var url = window.location.protocol + "//" + location.host + "/api/table";

	var response = await fetchAsync(url);//'{"dates": ["23.01", "22.01", "23.01"],"prices":[35.3, 32.2, 35.4] }';

	let dateArray = response.dates.reverse();
	let chartData = response.prices.map(i => Number(i.replace(',', '.'))).reverse();

	console.log(chartData);
	
	buildChart(dateArray, chartData);
}

async function fetchAsync(url) {
	let response = await fetch(url);
	let data = response.json();
	return data;
}
