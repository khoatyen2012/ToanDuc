using UnityEngine;
using System.Collections;

public class ClsLanguage {

    public static string doConMeo()
    {
        string vaothi = "con gà";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "chicken";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Huhn";
		}

        return vaothi;
    }

    public static string doQuaTao()
    {
        string vaothi = "quả táo";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "apple";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Apfel";
		}

        return vaothi;
    }

    public static string doBongHoa()
    {
        string vaothi = "bông hoa";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "flower";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Blume";
		}

        return vaothi;
    }

    public static string doLop5()
    {
        string vaothi = "Lớp 5";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Fifth";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Funfte";
		}

        return vaothi;
    }

    public static string doLop4()
    {
        string vaothi = "Lớp 4";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Fourth";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Vierte";
		}

        return vaothi;
    }

    public static string doLop3()
    {
        string vaothi = "Lớp 3";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Third";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Dritte";
		}

        return vaothi;
    }

    public static string doLop2()
    {
        string vaothi = "Lớp 2";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Second";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Zweite";
		}

        return vaothi;
    }

    public static string doLop1()
    {
        string vaothi = "Lớp 1";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "First";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Zuerst";
		}

        return vaothi;
    }

    public static string doHinhNguGiac()
    {
        string vaothi = "Hình ngũ giác";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Pentagon ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Pentagon ";
		}

        return vaothi;
    }

    public static string doHinhLucGiac()
    {
        string vaothi = "Hình lục giác";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Hexagon ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Hexagon ";
		}

        return vaothi;
    }

    public static string doHinhNgoiSao()
    {
        string vaothi = "Hình ngôi sao";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Star ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Star ";
		}

        return vaothi;
    }

    public static string doHinhChuNhat()
    {
        string vaothi = "Hình chữ nhật";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Rectangle ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Rechteck ";
		}

        return vaothi;
    }


    public static string doHinhTron()
    {
        string vaothi = "Hình tròn";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Circle ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Kreis ";
		}

        return vaothi;
    }

    public static string doHinhTamGiac()
    {
        string vaothi = "Hình tam giác";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Triangular";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Dreieckig";
		}

        return vaothi;
    }

    public static string doHinhVuong()
    {
        string vaothi = "Hình vuông";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Square ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Platz ";
		}

        return vaothi;
    }

    public static string doAnd()
    {
        string vaothi = " và ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = " and ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = " und ";
		}

        return vaothi;
    }


    public static string doChia()
    {
        string vaothi = "Thương ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Divide ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Teilen ";
		}

        return vaothi;
    }

    public static string doNhan()
    {
        string vaothi = "Tích ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Multiply ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Multiplizieren ";
		}

        return vaothi;
    }

    public static string doTong()
    {
        string vaothi = "Tổng ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Sum  ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Summe  ";
		}

        return vaothi;
    }


    public static string doHieu()
    {
        string vaothi = "Hiệu ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Subtract ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Subtrahieren ";
		}

        return vaothi;
    }

    public static string doNumber()
    {
        string vaothi = "Số ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Number ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Number ";
		}

        return vaothi;
    }



    public static string doBanCanMuaVip()
    {
        string vaothi = "\n\n(Để xem được lời giải thích đầy đủ bạn cần kích hoạt Vip)";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "\n\n(To get the full explanation you must be a member vip)";
		}else if(GameController.instance.tienganh==2)
		{
		}

        return vaothi;
    }

    public static string doOf()
    {
        string vaothi = " của ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = " of ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = " von ";
		}

        return vaothi;
    }


    public static string doDapSo()
    {
        string vaothi = "Đáp số: ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Result: ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Ergebnis: ";
		}

        return vaothi;
    }


    public static string doLoading()
    {
        string vaothi = "Vui lòng đợi....\nHệ thống đang soạn đề thi";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Loading...Please Wait";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Laden...bitte warten";
		}

        return vaothi;
    }


    public static string doFillNumber()
    {
        string vaothi = "Điền số thích hợp vào chỗ chấm (...) ?\n\n";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Fill in the missing number (...) ?\n\n";
		}else if(GameController.instance.tienganh==2)
		{
		}

        return vaothi;
    }

    public static string doTongKet()
    {
        string vaothi = "Tổng kết";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Summary";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Zusammenfassung";
		}

        return vaothi;
    }

    public static string doVuotQua()
    {
        string vaothi = "Bạn ĐÃ vượt qua vòng ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "You have exceeded the level ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Du hast das Level uberschritten ";
		}

        return vaothi;
    }
    public static string doChuaVuotQua()
    {
        string vaothi = "Bạn CHƯA vượt qua vòng ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "You do not pass the level ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Du uberholst das Level nicht ";
		}

        return vaothi;
    }

    public static string doTongDiem()
    {
        string vaothi = "Tổng điểm 3 bài thi là: ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "The total score of 3 tests: ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Die Gesamtpunktzahl von 3 Tests:";
		}

        return vaothi;
    }

    public static string doContentMoney()
    {
        string vaothi = "Bài 2: Bạn hãy dùng ngón tay. Chọn móc treo tấm bảng của mình sao cho số hoặc biểu thức trong bảng có giá trị bằng số hoặc biểu thức ghi trên móc treo.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Lesson 2: Please use your finger. Choose to hang your board so that the number or expression in the table has a numeric value or the expression written on the hook.";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Lektion 2: Bitte benutzen Sie Ihren Finger. Wahlen Sie, ob Sie die Karte so aufhangen mochten, dass die Zahl oder der Ausdruck in der Tabelle einen numerischen Wert hat oder der Ausdruck auf dem Hook steht.";
		}

        return vaothi;
    }

    public static string doTileSapXep()
    {
        string vaothi = "Sắp xếp";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Sort Ascending";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Aufsteigend sortieren";
		}

        return vaothi;
    }

    public static string doSapXep()
    {
        string vaothi = "Bài 1: Bạn hãy dùng ngón tay. Bạn chọn liên tiếp các ô có giá trị tăng dần để các ô lần lượt bị xóa khỏi bảng. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Lesson 1: Use your fingers. You select successive cells which have ascending values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Lektion 1: Benutze deine Finger. Sie wählen aufeinanderfolgende Zellen mit aufsteigenden Werten aus, um sie aus der Tabelle zu entfernen. Wenn Sie fälschlicherweise mehr als 3 Mal auswählen, wird Ihr Test beendet.";
		}

        return vaothi;
    }

    public static string doHoanThanhBaiThi()
    {
        string vaothi = "Bạn đã hoàn thành bài thi";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "You've completed the test";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Sie haben den Test abgeschlossen";
		}

        return vaothi;
    }


   


   


    public static string doTitleCapBangNhau()
    {
        string vaothi = "Tìm cặp bằng nhau";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Find pairs of equal";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Finde gleichwertige Paare";
		}

        return vaothi;
    }

    public static string doLesson()
    {
        string vaothi = "Bài ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Lesson ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Lektion ";
		}

        return vaothi;
    }

    public static string doContentCapBangNhau()
    {
        string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn liên tiếp 2 ô có giá trị bằng nhau hoặc đồng nhất với nhau. Khi chọn đúng, hai ô sẽ bị xóa khỏi bảng. Nếu chọn sai quá 3 lần bài thi sẽ kết thúc.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = " Use your fingers. You select successive cells which have same values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = " Benutze deine Finger. Sie wahlen aufeinanderfolgende Zellen aus, die dieselben Werte haben, um sie aus der Tabelle zu entfernen. Wenn Sie falschlicherweise mehr als 3 Mal auswahlen, wird Ihr Test beendet.";
		}

        return vaothi;
    }

    public static string doContentDinhNui()
    {
        string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn 1 trong bốn đáp cho phù hợp vào ô trống cho phù hợp với kết quả. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc. Nếu chọn đúng được cộng 10 điểm còn chọn sai trừ 2 điểm";
        if (GameController.instance.tienganh==0)
        {
            vaothi = " Use your fingers. You choose one of four answers in the box for matching results. If you select the wrong more than 3 times, the test will end.";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = " Benutze deine Finger. Sie wählen eine der vier Antworten in der Box fur die passenden Ergebnisse. Wenn Sie mehr als 3 Mal falsch auswahlen, wird der Test beendet.";
		}

        return vaothi;
    }

    public static string doDiem()
    {
        string vaothi = "Điểm ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Coin  ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Munze  ";
		}

        return vaothi;
    }

    public static string doTime()
    {
        string vaothi = "Thời gian ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Time ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Zeit ";
		}

        return vaothi;
    }


    public static string doGiaiThich()
    {
        string vaothi = "Lời giải: ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Solve: ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Losen: ";
		}

        return vaothi;
    }

    public static string doVaoThi()
    {
        string vaothi = "Vào thi";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Play";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Abspielen";
		}

        return vaothi;
    }
    public static string doContenQuangCao()
    {
        string vaothi = "Quảng cáo ứng dụng hữu ích sẽ được hiển thị cho bạn !";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "App advertising will be displayed !";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "App-Werbung wird angezeigt !";
		}

        return vaothi;
    }
    public static string doQuangCao()
    {
        string vaothi = "Quảng cáo";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Advertise";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Werben";
		}

        return vaothi;
    }

   

    public static string doMuaVip()
    {
		string vaothi = "Chia sẻ";
        if (GameController.instance.tienganh==0)
        {
			vaothi = "Share Game";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Spiel teilen";
		}

        return vaothi;
    }
    public static string doContenVip()
    {
        string vaothi = "1.Bạn có thể nhận được câu trả lời đầy đủ cho các đáp án sai tại bài thi Đỉnh núi trí tuệ. \n\n 2.Bạn sẽ không bị làm phiền bởi quảng cáo. \n\n 3.Ủng hộ chúng tôi 1 ít kinh phí để duy trì hoạt động làm cho ứng dụng tốt hơn.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "1.You can get the complete answer for the wrong answer in test Intellectual peaks. \n\n 2.You will not be bothered by ads after the end of the game.";
		}else if(GameController.instance.tienganh==2)
		{
		}

        return vaothi;
    }

    public static string doActiVip()
    {
        string vaothi = "Kích Hoạt Vip";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Member Vip";
		}else if(GameController.instance.tienganh==2)
		{
		}

        return vaothi;
    }

    public static string doBatDau()
    {
        string vaothi = "Vòng thi thứ ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Level ";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Niveau ";
		}

        return vaothi;
    }
    public static string doQuestion()
    {
        string vaothi = "Câu hỏi";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Question";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Frage";
		}

        return vaothi;
    }

    public static string doContentBatDau()
    {
        string vaothi = "-Bạn cần phải vượt qua 3 bài tập. Điểm thi của bạn phải >=50% của vòng thi bạn mới qua.\n-Phụ huynh học sinh vui lòng không thi hộ học sinh, đó là hành động vi phạm luật.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "You need to pass three exercises. Your score must be equal to or greater than 50 percent of the last round which you have just passed.";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Sie müssen drei ubungen bestehen. Ihre Punktzahl muss mindestens 50 Prozent der letzten Runde betragen, die Sie gerade passiert haben.";
		}

        return vaothi;
    }

    public static string doTitleDinhNui()
    {
        string vaothi = "Đỉnh núi trí tuệ";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Intellectual peaks";
		}else if(GameController.instance.tienganh==2)
		{
		}

        return vaothi;
    }

   

    public static string doStart()
    {
        string vaothi = "Bắt đầu";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Play";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Abspielen";
		}

        return vaothi;
    }

    public static string doContinute()
    {
        string vaothi = "Tiếp tục";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Continute";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Fortfahren";
		}

        return vaothi;
    }
    public static string doContentTuyetVoi()
    {
        string vaothi = "Thật là xuất sắc !  Bạn đã vượt qua được 20 vòng thi.";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Excellent ! You have crossed the 20 level";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Ausgezeichnet ! Du hast die 20 Level uberschritten";
		}

        return vaothi;
    }


    public static string doTitleTuyetVoi()
    {
        string vaothi = "Chúc mừng";
        if (GameController.instance.tienganh==0)
        {
            vaothi = "Excellent";
		}else if(GameController.instance.tienganh==2)
		{
			vaothi = "Ausgezeichnet";
		}

        return vaothi;
    }


}
