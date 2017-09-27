(function () {
	function printWhenReady() {
		if (window.PDFViewerApplication && window.PDFViewerApplication.initialized && window.PDFViewerApplication.pdfViewer.pageViewsReady) {
			window.print();
		}
		else {
			window.setTimeout(printWhenReady, 500);
		}
	};

	printWhenReady();
})();