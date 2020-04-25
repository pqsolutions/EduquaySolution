var loginService = function () {

};
app.service('loginService', loginService);

var mainController = function ($scope, $http) {
	$scope.user = {};
	$scope.user.Email = '';
	$scope.user.Password = '';
	$scope.user.CountryCode = '1';
	$scope.user.status = false;
	$scope.user.message = '';
	$scope.message = '';
	$scope.result = "color-default";
	$scope.isViewLoading = false;
	$scope.baseUrl = "http://localhost/Eduquayapi";

	$scope.loginUser = function () {
		var url = $scope.baseUrl + "/api/v1/Patient/GetPatients";
		var postData = {
			"email": $scope.user.Email,
			"password": $scope.user.Password
		};

		var headerDict = {
			"Content-Type": "application/json",
			"Accept": "application/json",
			'Access-Control-Allow-Origin': '*',
			'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
			'Access-Control-Allow-Headers': "Origin, X-Requested-With, Content-Type, Accept"
		};

		var headers1 = {
			// 'Authorization': 'Basic ' + btoa(username + ":" + password),
			'Access-Control-Allow-Origin': true,
			'Content-Type': 'application/json; charset=utf-8',
			"X-Requested-With": "XMLHttpRequest"
		}

		var headers = new Headers();
		headers.append('Content-Type', 'application/json');

		const requestOptions = {
			headers: new Headers(headerDict)
		};

		$.ajax({
			url: url,
			//data: postData,
			type: 'get',
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded',
				"Accept": "application/json",
				'Access-Control-Allow-Origin': '*',
				'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
				'Access-Control-Allow-Headers': "Origin, X-Requested-With, Content-Type, Accept"
			},
			success: function (data) {
				alert('OK');
			},
			error: function (error, status) {
				console.log('here');
				console.log(error);
				alert('some error' + error);
			}
		});

		
		console.log('done');
		//try {

		//	$http.post(url, postData, requestOptions)
		//		.then(function successCallback(response) {
		//			$scope.messageStatus = "alert alert-success";
		//			if (response.data != null) {
		//				$scope.user.status = response.data.status;
		//				$scope.user.message = response.data.message;
		//				$scope.user.user = response.data.user;

		//				//if ($scope.cust.status) {
		//				//	$http.post('/api/auth/data', response.data.user)
		//				//		.then(
		//				//			function successCallback(authresponse) {
		//				//				if (authresponse.data != null && authresponse.data.status) {
		//				//					console.log('Data posted successfully');
		//				//					localStorage.setItem('token', response.data.token);
		//				//					$scope.RedirectToURL('/');
		//				//				}
		//				//			}, function errorCallback(errorresponse) {
		//				//				console.log(errorresponse.data);
		//				//			});
		//				//}
		//			}
		//		}, function errorCallback(response) {
		//			if (response.status <= -1) {
		//				$scope.user.message = "Api server is not available";
		//				console.log($scope.message);
		//			}
		//			else if (response.data !== null) {
		//				$scope.user.message = response.data.message;
		//				console.log($scope.user.message);
		//			}
		//		});
		//} catch (e) {
		//	console.log(e);
		//}
		return false;
	};

};


app.controller('cmcController', ['$scope', '$http', mainController]);
