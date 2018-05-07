using UnityEngine;
using System.Collections;

public class ClsLanguage {

    public static string doConMeo()
    {
        string vaothi = "con gà";
        if (GameController.instance.tienganh)
        {
            vaothi = "chicken";
        }

        return vaothi;
    }

    public static string doQuaTao()
    {
        string vaothi = "quả táo";
        if (GameController.instance.tienganh)
        {
            vaothi = "apple";
        }

        return vaothi;
    }

    public static string doBongHoa()
    {
        string vaothi = "bông hoa";
        if (GameController.instance.tienganh)
        {
            vaothi = "flower";
        }

        return vaothi;
    }

    public static string doLop5()
    {
        string vaothi = "Lớp 5";
        if (GameController.instance.tienganh)
        {
            vaothi = "Fifth";
        }

        return vaothi;
    }

    public static string doLop4()
    {
        string vaothi = "Lớp 4";
        if (GameController.instance.tienganh)
        {
            vaothi = "Fourth";
        }

        return vaothi;
    }

    public static string doLop3()
    {
        string vaothi = "Lớp 3";
        if (GameController.instance.tienganh)
        {
            vaothi = "Third";
        }

        return vaothi;
    }

    public static string doLop2()
    {
        string vaothi = "Lớp 2";
        if (GameController.instance.tienganh)
        {
            vaothi = "Second";
        }

        return vaothi;
    }

    public static string doLop1()
    {
        string vaothi = "Lớp 1";
        if (GameController.instance.tienganh)
        {
            vaothi = "First";
        }

        return vaothi;
    }

    public static string doHinhNguGiac()
    {
        string vaothi = "Hình ngũ giác";
        if (GameController.instance.tienganh)
        {
            vaothi = "Pentagon ";
        }

        return vaothi;
    }

    public static string doHinhLucGiac()
    {
        string vaothi = "Hình lục giác";
        if (GameController.instance.tienganh)
        {
            vaothi = "Hexagon ";
        }

        return vaothi;
    }

    public static string doHinhNgoiSao()
    {
        string vaothi = "Hình ngôi sao";
        if (GameController.instance.tienganh)
        {
            vaothi = "Star ";
        }

        return vaothi;
    }

    public static string doHinhChuNhat()
    {
        string vaothi = "Hình chữ nhật";
        if (GameController.instance.tienganh)
        {
            vaothi = "Rectangle ";
        }

        return vaothi;
    }


    public static string doHinhTron()
    {
        string vaothi = "Hình tròn";
        if (GameController.instance.tienganh)
        {
            vaothi = "Circle ";
        }

        return vaothi;
    }

    public static string doHinhTamGiac()
    {
        string vaothi = "Hình tam giác";
        if (GameController.instance.tienganh)
        {
            vaothi = "Triangular";
        }

        return vaothi;
    }

    public static string doHinhVuong()
    {
        string vaothi = "Hình vuông";
        if (GameController.instance.tienganh)
        {
            vaothi = "Square ";
        }

        return vaothi;
    }

    public static string doAnd()
    {
        string vaothi = " và ";
        if (GameController.instance.tienganh)
        {
            vaothi = " and ";
        }

        return vaothi;
    }


    public static string doChia()
    {
        string vaothi = "Thương ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Divide ";
        }

        return vaothi;
    }

    public static string doNhan()
    {
        string vaothi = "Tích ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Multiply ";
        }

        return vaothi;
    }

    public static string doTong()
    {
        string vaothi = "Tổng ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Sum  ";
        }

        return vaothi;
    }


    public static string doHieu()
    {
        string vaothi = "Hiệu ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Subtract ";
        }

        return vaothi;
    }

    public static string doNumber()
    {
        string vaothi = "Số ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Number ";
        }

        return vaothi;
    }

    public static string doSoLienTruoc()
    {
        string vaothi = "Số liền trước ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Previous number ";
        }

        return vaothi;
    }

    public static string doSoLienSau()
    {
        string vaothi = "Số liền sau ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Next number ";
        }

        return vaothi;
    }

    public static string doBanCanMuaVip()
    {
        string vaothi = "\n\n(Để xem được lời giải thích đầy đủ bạn cần kích hoạt Vip)";
        if (GameController.instance.tienganh)
        {
            vaothi = "\n\n(To get the full explanation you must be a member vip)";
        }

        return vaothi;
    }

    public static string doOf()
    {
        string vaothi = " của ";
        if (GameController.instance.tienganh)
        {
            vaothi = " of ";
        }

        return vaothi;
    }


    public static string doDapSo()
    {
        string vaothi = "Đáp số: ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Result: ";
        }

        return vaothi;
    }


    public static string doLoading()
    {
        string vaothi = "Vui lòng đợi....\nHệ thống đang soạn đề thi";
        if (GameController.instance.tienganh)
        {
            vaothi = "Loading...Please Wait";
        }

        return vaothi;
    }


    public static string doFillNumber()
    {
        string vaothi = "Điền số thích hợp vào chỗ chấm (...) ?\n\n";
        if (GameController.instance.tienganh)
        {
            vaothi = "Fill in the missing number (...) ?\n\n";
        }

        return vaothi;
    }

    public static string doTongKet()
    {
        string vaothi = "Tổng kết";
        if (GameController.instance.tienganh)
        {
            vaothi = "Summary";
        }

        return vaothi;
    }

    public static string doVuotQua()
    {
        string vaothi = "Bạn ĐÃ vượt qua vòng ";
        if (GameController.instance.tienganh)
        {
            vaothi = "You have exceeded the level ";
        }

        return vaothi;
    }
    public static string doChuaVuotQua()
    {
        string vaothi = "Bạn CHƯA vượt qua vòng ";
        if (GameController.instance.tienganh)
        {
            vaothi = "You do not pass the level ";
        }

        return vaothi;
    }

    public static string doTongDiem()
    {
        string vaothi = "Tổng điểm 3 bài thi là: ";
        if (GameController.instance.tienganh)
        {
            vaothi = "The total score of 3 tests: ";
        }

        return vaothi;
    }

    public static string doContentMoney()
    {
        string vaothi = "Bài 3: Bạn hãy dùng ngón tay. Chọn móc treo tấm bảng của mình sao cho số hoặc biểu thức trong bảng có giá trị bằng số hoặc biểu thức ghi trên móc treo.";
        if (GameController.instance.tienganh)
        {
            vaothi = "Lesson 3: Please use your finger. Choose to hang your board so that the number or expression in the table has a numeric value or the expression written on the hook.";
        }

        return vaothi;
    }

    public static string doTileSapXep()
    {
        string vaothi = "Sắp xếp";
        if (GameController.instance.tienganh)
        {
            vaothi = "Sort Ascending";
        }

        return vaothi;
    }

    public static string doSapXep()
    {
        string vaothi = "Bài 1: Bạn hãy dùng ngón tay. Bạn chọn liên tiếp các ô có giá trị tăng dần để các ô lần lượt bị xóa khỏi bảng. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc.";
        if (GameController.instance.tienganh)
        {
            vaothi = "Lesson 1: Use your fingers. You select successive cells which have ascending values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
        }

        return vaothi;
    }

    public static string doHoanThanhBaiThi()
    {
        string vaothi = "Bạn đã hoàn thành bài thi";
        if (GameController.instance.tienganh)
        {
            vaothi = "You've completed the test";
        }

        return vaothi;
    }


   


   


    public static string doTitleCapBangNhau()
    {
        string vaothi = "Tìm cặp bằng nhau";
        if (GameController.instance.tienganh)
        {
            vaothi = "Find pairs of equal";
        }

        return vaothi;
    }

    public static string doLesson()
    {
        string vaothi = "Bài ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Lesson ";
        }

        return vaothi;
    }

    public static string doContentCapBangNhau()
    {
        string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn liên tiếp 2 ô có giá trị bằng nhau hoặc đồng nhất với nhau. Khi chọn đúng, hai ô sẽ bị xóa khỏi bảng. Nếu chọn sai quá 3 lần bài thi sẽ kết thúc.";
        if (GameController.instance.tienganh)
        {
            vaothi = " Use your fingers. You select successive cells which have same values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
        }

        return vaothi;
    }

    public static string doContentDinhNui()
    {
        string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn 1 trong bốn đáp cho phù hợp vào ô trống cho phù hợp với kết quả. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc. Nếu chọn đúng được cộng 10 điểm còn chọn sai trừ 2 điểm";
        if (GameController.instance.tienganh)
        {
            vaothi = " Use your fingers. You choose one of four answers in the box for matching results. If you select the wrong more than 3 times, the test will end.";
        }

        return vaothi;
    }

    public static string doDiem()
    {
        string vaothi = "Điểm ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Coin  ";
        }

        return vaothi;
    }

    public static string doTime()
    {
        string vaothi = "Thời gian ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Time ";
        }

        return vaothi;
    }


    public static string doGiaiThich()
    {
        string vaothi = "Lời giải: ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Solve: ";
        }

        return vaothi;
    }

    public static string doVaoThi()
    {
        string vaothi = "Vào thi";
        if (GameController.instance.tienganh)
        {
            vaothi = "Play";
        }

        return vaothi;
    }
    public static string doContenQuangCao()
    {
        string vaothi = "Quảng cáo ứng dụng hữu ích sẽ được hiển thị cho bạn !";
        if (GameController.instance.tienganh)
        {
            vaothi = "App advertising will be displayed !";
        }

        return vaothi;
    }
    public static string doQuangCao()
    {
        string vaothi = "Quảng cáo";
        if (GameController.instance.tienganh)
        {
            vaothi = "Advertise";
        }

        return vaothi;
    }

   

    public static string doMuaVip()
    {
        string vaothi = "Kích Hoạt Vip";
        if (GameController.instance.tienganh)
        {
            vaothi = "Buy Vip";
        }

        return vaothi;
    }
    public static string doContenVip()
    {
        string vaothi = "1.Bạn có thể nhận được câu trả lời đầy đủ cho các đáp án sai tại bài thi Đỉnh núi trí tuệ. \n\n 2.Bạn sẽ không bị làm phiền bởi quảng cáo. \n\n 3.Ủng hộ chúng tôi 1 ít kinh phí để duy trì hoạt động làm cho ứng dụng tốt hơn.";
        if (GameController.instance.tienganh)
        {
            vaothi = "1.You can get the complete answer for the wrong answer in test Intellectual peaks. \n\n 2.You will not be bothered by ads after the end of the game.";
        }

        return vaothi;
    }

    public static string doActiVip()
    {
        string vaothi = "Kích Hoạt Vip";
        if (GameController.instance.tienganh)
        {
            vaothi = "Member Vip";
        }

        return vaothi;
    }

    public static string doBatDau()
    {
        string vaothi = "Vòng thi thứ ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Level ";
        }

        return vaothi;
    }
    public static string doQuestion()
    {
        string vaothi = "Câu hỏi";
        if (GameController.instance.tienganh)
        {
            vaothi = "Question";
        }

        return vaothi;
    }

    public static string doContentBatDau()
    {
        string vaothi = "-Bạn cần phải vượt qua 3 bài tập. Điểm thi của bạn phải >=50% của vòng thi bạn mới qua.\n-Phụ huynh học sinh vui lòng không thi hộ học sinh, đó là hành động vi phạm luật.";
        if (GameController.instance.tienganh)
        {
            vaothi = "You need to pass three exercises. Your score must be equal to or greater than 50 percent of the last round which you have just passed.";
        }

        return vaothi;
    }

    public static string doTitleDinhNui()
    {
        string vaothi = "Đỉnh núi trí tuệ";
        if (GameController.instance.tienganh)
        {
            vaothi = "Intellectual peaks";
        }

        return vaothi;
    }

   

    public static string doStart()
    {
        string vaothi = "Bắt đầu";
        if (GameController.instance.tienganh)
        {
            vaothi = "Play";
        }

        return vaothi;
    }

    public static string doContinute()
    {
        string vaothi = "Tiếp tục";
        if (GameController.instance.tienganh)
        {
            vaothi = "Continute";
        }

        return vaothi;
    }
    public static string doContentTuyetVoi()
    {
        string vaothi = "Thật là xuất sắc !  Bạn đã vượt qua được 20 vòng thi.";
        if (GameController.instance.tienganh)
        {
            vaothi = "Excellent ! You have crossed the 20 level";
        }

        return vaothi;
    }


    public static string doTitleTuyetVoi()
    {
        string vaothi = "Chúc mừng";
        if (GameController.instance.tienganh)
        {
            vaothi = "Excellent";
        }

        return vaothi;
    }


}
