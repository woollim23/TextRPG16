using System;

namespace TextRPG16
{
    class Thief : User
    {
        public Thief() // ������
        {
            UserClass = "����";
            FullHP = 100; // �ʱ� ü��
            HP = 100; // �ʱ� ü��
            FullMP = 200; // �ʱ� ����
            MP = FullMP; // �ʱ� ����
            DefensPower = 40; // �ʱ� ����
            AttackDamage = 12; // �ʱ� ���ݷ�
        }

    }
}