<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QL_Nhom.ascx.cs" Inherits="ThuVienSach.QL_Nhom" %>


<%--Datatable--%>
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

<div class="panel-input">
    <div class="header-panel">
        Chỉnh Sửa Dữ Liệu
    </div>

    <div class="content-panel-input">
        <table class="table table-responsive">
            <tr>
                <td>Tên Thể Loại: </td>
                <td>
                    <asp:TextBox ID="txtTenNhom" runat="server" autocomplete="off" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="KTNhom" ValidationGroup="Check" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTenNhom"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <div class="Event-Click">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-info" ValidationGroup="Check" OnClick="btnThem_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được thêm vào ?')) return false;" />&emsp;
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" CssClass="btn btn-success" ValidationGroup="Check" OnClick="btnCapNhat_Click" OnClientClick="if(!confirm('Dữ liệu sẽ được cập nhật ?')) return false;" />&emsp;
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnXoa_Click" OnClientClick="if(!confirm('Dữ liệu sẽ bị xóa ?')) return false;" />&emsp;
        </div>
    </div>
</div>

<div class="content-show-data">
    <div class="header-panel">
        Hiển Thị Dữ Liệu
    </div>

    <div class="content-panel-show-data">
        <asp:GridView ID="tableNhomSach" ClientIDMode="Static" runat="server" CssClass="display cell-border" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MaNhom" HeaderText="Mã Thể Loại" />
                <asp:BoundField DataField="TenNhom" HeaderText="tên Thể Loại" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<script type="text/javascript">
    //code chay table
    $(document).ready(function () {
        $("#tableNhomSach").DataTable({

            language: {
                "sProcessing": "Đang xử lý...",
                "sLengthMenu": "Xem _MENU_ mục",
                "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
                "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
                "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
                "sInfoFiltered": "(được lọc từ _MAX_ mục)",
                "sInfoPostFix": "",
                "sSearch": "Tìm Kiếm:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "Đầu",
                    "sPrevious": "Trước",
                    "sNext": "Tiếp",
                    "sLast": "Cuối"
                }
            },
        });
    });

    $('#tableNhomSach tbody').on('click', 'tr', function () {
        var s = $(this).closest("tr").find("td").first().text().trim();

        window.location.href = "/QuanLyNhomSach/Nhom/" + s;
    });

</script>
