# User Stories – EduHub

## tác nhân: Sinh viên

### US-01: Đăng ký tham gia CLB
As a **sinh viên**, I want **đăng ký tham gia một CLB**, so that **tôi trở thành thành viên và nhận thông báo sự kiện**.

**Tiêu chí nghiệm thu**
- Given tôi chưa là thành viên CLB, When tôi gửi đăng ký với đủ họ tên, email, mã số sinh viên, Then hệ thống ghi nhận yêu cầu ở trạng thái chờ duyệt.
- Given tôi đã là thành viên CLB, When tôi đăng ký lại, Then hệ thống báo lỗi "đã tham gia".

### US-02: Đăng ký sự kiện
As a **sinh viên**, I want **đăng ký tham dự một sự kiện**, so that **tôi có chỗ chắc chắn**.

**Tiêu chí nghiệm thu**
- Given sự kiện còn chỗ, When tôi đăng ký, Then phiếu đăng ký có trạng thái Pending.
- Given sự kiện đã đủ Capacity, When tôi đăng ký, Then hệ thống từ chối và hiển thị thông báo hết chỗ.

### US-03: Check-in tại sự kiện
As a **sinh viên**, I want **check-in khi đến sự kiện**, so that **việc tham dự của tôi được ghi nhận**.

**Tiêu chí nghiệm thu**
- Given phiếu đăng ký đã Confirmed, When tôi check-in, Then hệ thống tạo bản ghi CheckIn kèm thời điểm.
- Given phiếu đăng ký đã Cancelled, When tôi check-in, Then hệ thống từ chối.

## tác nhân: Ban CLB

### US-04: Tạo sự kiện
As a **thành viên Ban CLB**, I want **tạo sự kiện với tiêu đề, ngày, sức chứa**, so that **sinh viên có thể đăng ký**.

**Tiêu chí nghiệm thu**
- Given tôi nhập đủ thông tin hợp lệ, When tôi tạo sự kiện, Then sự kiện được gắn với CLB của tôi.
- Given Capacity ≤ 0 hoặc tiêu đề trống, When tôi tạo sự kiện, Then hệ thống báo lỗi dữ liệu.

### US-05: Xuất báo cáo tham dự
As a **thành viên Ban CLB**, I want **xem báo cáo số đăng ký, số check-in và danh sách người tham dự**, so that **tôi đánh giá hiệu quả sự kiện**.

**Tiêu chí nghiệm thu**
- Given sự kiện đã diễn ra, When tôi mở báo cáo, Then thấy tổng đăng ký và tổng check-in.
- Given có người đã check-in, When tôi mở báo cáo, Then thấy danh sách tên người tham dự.

## tác nhân: Admin

### US-06: Phê duyệt thành viên
As an **admin**, I want **phê duyệt hoặc từ chối yêu cầu gia nhập CLB**, so that **chỉ sinh viên hợp lệ mới là thành viên**.

**Tiêu chí nghiệm thu**
- Given có yêu cầu đang chờ, When tôi phê duyệt, Then sinh viên được thêm vào danh sách thành viên CLB.
- Given tôi từ chối yêu cầu, When thao tác hoàn tất, Then sinh viên không có trong danh sách thành viên.
