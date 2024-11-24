# RideOrDie
BTU Game Programming Midterm project

# Oynanış Hakkında Bilgilendirme 
<p> Oyun Mouse imleciyle oynanır. İmleci arabanın ortasına getirerek arabayı yavaşlatabilirsiniz.Çimene - toprağa bastığınızda yavaşlarsınız. Topraktan çıkınca eski hızınıza geri dönersiniz. Geçici ve kalıcı olmak üzere iki adet buff bulunmakta. Ayrıca diğer arabalara ve kare kare olan minecraft çimenlerine çarpmamaya dikkat etmelisiniz yoksa patlarsınız. </p>

# Aksiyon Listesi
<ul> Adem Berk Yuksel - 21360859055
<li> Oyuncunun İmlece doğru yüzünü belirli bir açıda dönmesi için mutlak hızın hesaplanması CarEntity.cs:131 </li>
<li> Oyuncunun imlecin pozisyonuna bağlı olarak hedef açının hesaplanması CarEntity.cs:122 </li>
<li> Oyuncunun mouse pozisyonunun karakterin collider'ına değip değmemesini kontrol etme CarEntity.cs:173</li>
<li> Oyuncunun bitki engeline takılıp takılmadığını kontrol etme ForestObstacle.cs:8</li>
<li> Oyuncunun dönme açısının kısıtlanması CarEntity.cs:125 //NOT: if() in kontrol bloğunda değil gövdesinde bu işlemi yaptım. Aksiyon sayılır mı bilemedim.</li>

</ul>


<ul> Mustafa Durmazer - 21360859041
<li> Oyuncunun diğer arabalara çarpıp çarpmadığının kontrol edilmesi ExplosionTrigger.cs:18 </li>
<li> Oyuncunun Permanent Acceleration buff'ını alıp almadığının kontrol edilmesi PermanentAccelaration.cs:20</li>
<li> Oyuncuyu yavaşlatan toprağa basıp basmadığımızın kontrol edilmesi SlowDown.cs:20 </li>
<li> Oyuncunun topraktan çıktıkta sonra eski hızına dönmesi SlowDown.cs:27</li>
<li> Oyuncunun Temporary Acceleration buff'ını alıp almadığının kontrol edilmesi TemporaryAccelaration.cs:23</li>


</ul>
