namespace TextRPG16
{
    class Monster : ICharacter{
        // ------------------ ĳ���� �������̽� ���� ------------------
        string _name = null!; // �̸�  // - �ڽĵ� ��������
        int _level;
        string _tribe = null!; // ����
        int _HP; // ���� ����
        int _fullHP; // �ִ�����
        int _attackDamage; // ���ݷ�
        bool _isDead; // ��������

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } private set { _level = value; } } // ����
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } protected set { _HP = value; } }
        public int FullHP { get { return _fullHP; } protected set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } protected set { _attackDamage = value; } }
        public bool IsDead { get { return _isDead; } private set { _isDead = value; } }

        public void TakeDamage(int damage)
        {

        }
    }

    class Dookie: Monster
    {
        public Dookie()
        {

        }
    }

    class Slime: Monster
    {
        public Slime()
        {

        }
    }

    class Leejinho: Monster
    {
        public Leejinho()
        {

        }
    }

    class Dragon: Monster
    {
        public Dragon()
        {

        }
    }
}
