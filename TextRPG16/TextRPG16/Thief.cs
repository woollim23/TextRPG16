using System;

namespace TextRPG16
{
    class Thief : User
    {
        public Thief() // ������
        {
            UserClass = "����";
            HP = 100; // �ʱ� ü��
            DefensPower = 10; // �ʱ� ����
            AttackDamage = 15; // �ʱ� ���ݷ�

        }

        // ������ ó�� �޼���
        public void TakeDamage(int damage)
        {
            HP -= damage; // ��������ŭ ü�� ����

            if (IsDead) Console.WriteLine($"{Name}��(��) �׾����ϴ�.");
            else Console.WriteLine($"{Name}��(��) {damage}�� �������� �޾ҽ��ϴ�. ���� ü��: {HP}");
        }

    }
}