# Odn

# Bootstrapper ������

# Module ģ�黯˼��
* ÿ��Project��Ϊһ��Module 

# Ioc ��������

## �ر��
* ���������������Խ��벻ͬ������

�ܹ�ģʽ��
NHibernate + FluentNHibernate �����������������. Ĭ�Ͽ����ӳټ���

���ֵ������ ͨ��AutoMapper��ת��

���ӵı������ ͨ��NHibernate Mapping + �ӳټ��� + Redis Cache

��ȡ���ݣ� MulitCritialQuery + Stateless Session

IOC����������, ����������ڲ��Ķ������, ���ýӿڽ���

�߳����ԣ� �߳������Ϣ

�쳣�������(��ӦӦ�ó����ܵ��쳣�������, ����Ӧ���쳣���� �ӿڷ�����쳣�Խ�)

�����㼶��Interception ����(Castle.DynamicProxy)

Dto, ViewModel, Entity�Ĺ�����֤(FluentValidation)

�������ʵ���Ȩ(Authorization)

Logging����

Cache����: �����(�ֲ�ʽЧ�ʵ���)�� �������(�ֲ�ʽ֧��), ��ȡ��������Ի��ƣ� Connection���Ի���

Pub/Sub: 
	AppDomain�ڲ���Pub/Sub(Ioc�������Ϣ����, 
	��Ϣִ�������ĵ��߳�ͬ��/�첽����, �������ҵ���߳��Ƿ�ͬ�������첽, �첽��֮����������), 
	
	�ⲿ��Pub/Sub(�ⲿ����Ϣ����)�� RabbitMQ, ֪ͨ�����ͣ� ���յ�����

	BusinessConsumer
	ScheduleService(Layer)

	��������� Ӧ�ó���ʶ��
	����ͬ��
	��������
