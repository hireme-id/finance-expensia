<div id="loadingTable" class="d-flex justify-content-center mt-2">
                            <i class="fa fa-spinner fa-spin fa-2x fa-fw mr-2"></i><br /><span class="pt-1">Loading...</span>
                        </div>

                        line 241 setelah tabel Detail.cshtml


                        ("#loadingTable").attr("style", "display: none !important");

                        detailpoa.js line 739 749 757 bagian  $('#tblPaidTo').DataTable({


                            $("tbody").attr("style", "filter: opacity(0.5)");
                            listpoa line 240

                            $("tbody").attr("style", "filter: none");
                            listpoa line 264