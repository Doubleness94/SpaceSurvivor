using UnityEngine;

//�������� ���� �� �ִ� Ÿ�Ե��� ���������� ������ �ϴ� �������̽�
public interface IDamageable
{
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
//�������� ���� �� �ִ� Ÿ�Ե��� IDamageable�� ����ϰ� OnDamage �޼��带 �ݵ�� �����ؾ� �Ѵ�.
//OnDamage �޼���� �Է����� ������ ũ��(damage), ���� ���� (hitPoint), ���� ǥ���� ����(hitNormal)�� �޴´�
