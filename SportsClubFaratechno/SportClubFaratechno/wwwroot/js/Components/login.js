
Vue.component('login', {
    data: function () {
        return {
            userName: "",
            password: "",
            snackbar: false,
            text: 'نام کاربری یا رمز  اشتباه است .',
            timeout: 3000,
            count:0
        }
    },
    methods: {
        login: async function () {

            var theUserName = this.userName;
            var thePassword = this.password;
            var LoginModel = { UserName: theUserName, Passwrod: thePassword };
            var vv;
            await axios.post("/General/Login", LoginModel).then(response => vv = response).catch(err => console.log(err));

            if (vv.data.token == "true") {
                window.location.href = "/Home/Index";
            }
            else {
                this.snackbar = true;

            }
        }
    },
    template: `
<div style="text-align: right; direction: rtl; width: 322px;  margin: auto;">
        <v-text-field label="نام کاربری"
                      hide-details="auto" v-model="userName"></v-text-field>
        <v-text-field label="رمز عبور" v-model="password"></v-text-field>
        <v-btn v-on:click="login()">ورود</v-btn>

        <v-snackbar v-model="snackbar"
                    :timeout="timeout">
            {{ text }}

            <template v-slot:action="{ attrs }">
                <v-btn color="red"
                       text
                       v-bind="attrs"
                       @click="snackbar = false">
                    Close
                </v-btn>
            </template>
        </v-snackbar>

    </div>
`
})



